using System;
using System.Collections.Generic;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks
{
    public class LibraryBookListVm
    {
        public Guid LibraryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public ICollection<LibraryBookDto> Books { get; set; }
    }
}
