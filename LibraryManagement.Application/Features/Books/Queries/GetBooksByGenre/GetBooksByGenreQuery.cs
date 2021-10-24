using MediatR;
using System.Collections.Generic;

namespace LibraryManagement.Application.Features.Books.Queries.GetBooksByGenre
{
    public class GetBooksByGenreQuery : IRequest<List<BookListGenreVm>>
    {
        public string Genre { get; set; }
    }
}
