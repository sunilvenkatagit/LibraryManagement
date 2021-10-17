using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Domain.Entities
{
    public class Author : AuditableEntity
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
