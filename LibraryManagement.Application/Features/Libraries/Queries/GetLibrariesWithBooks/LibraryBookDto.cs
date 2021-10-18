﻿using System;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks
{
    public class LibraryBookDto
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
