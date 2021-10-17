using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Domain.Entities
{
    public class Library : AuditableEntity
    {
        public Guid LibraryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
