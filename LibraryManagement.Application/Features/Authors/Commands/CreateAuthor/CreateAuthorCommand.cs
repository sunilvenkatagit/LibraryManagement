using MediatR;
using System;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
