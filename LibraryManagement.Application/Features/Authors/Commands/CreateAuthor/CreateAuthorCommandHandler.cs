using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepositoy;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepositoy, IMapper mapper)
        {
            _authorRepositoy = authorRepositoy;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuthorCommandValidator(_authorRepositoy);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var @author = _mapper.Map<Author>(request);
            @author = await _authorRepositoy.AddAsync(author);

            return author.AuthorId;
        }
    }
}
