using MediatR;
using System;

namespace LibraryManagement.Application.Features.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
