using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Books.Queries.GetBooksByGenre
{
    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, List<BookListGenreVm>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksByGenreQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookListGenreVm>> Handle(GetBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var booksByGenre = await _bookRepository.GetAllBooksByGenre(request.Genre);
            return _mapper.Map<List<BookListGenreVm>>(booksByGenre);
        }
    }
}
