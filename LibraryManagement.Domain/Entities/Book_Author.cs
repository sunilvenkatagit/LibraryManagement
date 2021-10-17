using LibraryManagement.Domain.Common;
using System;

namespace LibraryManagement.Domain.Entities
{
    public class Book_Author : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
