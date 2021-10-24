using MediatR;
using System;

namespace LibraryManagement.Application.Features.Libraries.Commands.DeleteLibrary
{
    public class DeleteLibraryCommand : IRequest
    {
        public Guid LibraryId { get; set; }
    }
}
