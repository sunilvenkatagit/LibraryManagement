﻿using System;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks
{
    public class Library_BookDto
    {
        public Guid BookId { get; set; }
        public LibraryBookDto Book { get; set; }
    }
}