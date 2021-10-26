using MediatR;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid PublisherId { get; set; }
        public List<Guid> AuthorIds { get; set; }
        public Guid LibraryId { get; set; }
    }
}
