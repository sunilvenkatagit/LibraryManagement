using System;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesByLocation
{
    public class LibraryListLocationVm
    {
        public Guid LibraryId { get; set; }
        public string Name { get; set; }
        public DateTime? EstablishedDate { get; set; }
    }
}
