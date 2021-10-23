using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Commands.CreateLibrary
{
    public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, Guid>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public CreateLibraryCommandHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLibraryCommandValidator(_libraryRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var @library = _mapper.Map<Library>(request);
            @library = await _libraryRepository.AddAsync(@library);

            return library.LibraryId;
        }
    }
}
