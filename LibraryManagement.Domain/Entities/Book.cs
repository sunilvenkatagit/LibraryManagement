using LibraryManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime? DateAdded { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
