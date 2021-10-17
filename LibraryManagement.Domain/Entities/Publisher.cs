using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Domain.Entities
{
    public class Publisher : AuditableEntity
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
