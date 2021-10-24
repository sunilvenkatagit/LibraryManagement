using MediatR;
using System;
using System.Collections.Generic;


namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks
{
    public class GetLibrariesWithBooksQuery : IRequest<List<LibraryBookListVm>>
    {
        public Guid LibraryId { get; set; }
    }
}
