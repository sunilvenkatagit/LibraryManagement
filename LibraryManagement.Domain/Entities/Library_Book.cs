using LibraryManagement.Domain.Common;
using System;

namespace LibraryManagement.Domain.Entities
{
    public class Library_Book : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
