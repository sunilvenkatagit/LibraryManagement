using MediatR;
using System;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid AuthorId { get; set; }
    }
}
