using MediatR;
using System;

namespace LibraryManagement.Application.Features.Libraries.Commands.UpdateLibrary
{
    public class UpdateLibraryCommand : IRequest
    {
        public Guid LibraryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? EstablishedDate { get; set; }
    }
}
