using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBoookCommandHandler : IRequestHandler<DeleteBoookCommand>
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBoookCommandHandler(IAsyncRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBoookCommand request, CancellationToken cancellationToken)
        {
            var bookToDelete = await _bookRepository.GetByIdAsync(request.BookId);
            if (bookToDelete == null)
                throw new NotFoundException(nameof(Book), request.BookId);

            await _bookRepository.DeleteAsync(bookToDelete);
            return Unit.Value;
        }
    }
}
