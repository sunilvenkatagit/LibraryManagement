using MediatR;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid PublisherId { get; set; }
        public List<Guid> AuthorIds { get; set; }
        public Guid LibraryId { get; set; }
    }
}
