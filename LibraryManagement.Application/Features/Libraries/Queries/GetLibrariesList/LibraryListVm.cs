using System;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesList
{
    public class LibraryListVm
    {
        public Guid LibraryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? EstablishedDate { get; set; }
    }
}
