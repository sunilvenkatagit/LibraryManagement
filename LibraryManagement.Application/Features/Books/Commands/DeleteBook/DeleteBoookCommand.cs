using MediatR;
using System;

namespace LibraryManagement.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBoookCommand : IRequest
    {
        public Guid BookId { get; set; }
    }
}
