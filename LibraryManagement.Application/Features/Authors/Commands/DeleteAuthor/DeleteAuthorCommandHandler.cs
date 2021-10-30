using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAsyncRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAsyncRepository<Author> asyncRepository, IMapper mapper)
        {
            _authorRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToDelete = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (authorToDelete == null)
                throw new NotFoundException(nameof(Author), request.AuthorId);

            await _authorRepository.DeleteAsync(authorToDelete);
            return Unit.Value;
        }
    }
}
