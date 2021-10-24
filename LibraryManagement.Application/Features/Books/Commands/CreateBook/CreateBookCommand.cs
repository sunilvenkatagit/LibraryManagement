using MediatR;
using System;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid PulisherId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid LibraryId { get; set; }
    }
}
