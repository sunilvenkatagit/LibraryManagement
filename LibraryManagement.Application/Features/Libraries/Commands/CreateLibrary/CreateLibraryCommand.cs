using MediatR;
using System;

namespace LibraryManagement.Application.Features.Libraries.Commands.CreateLibrary
{
    public class CreateLibraryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public override string ToString()
        {
            return $"Library Name: {Name}; Location: {Location}; Established Date: {EstablishedDate.Value.ToShortDateString()}";
        }
    }
}
