using MediatR;
using System.Collections.Generic;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesByLocation
{
    public class GetLibrariesByLocationQuery : IRequest<List<LibraryListLocationVm>>
    {
        public string Location { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
