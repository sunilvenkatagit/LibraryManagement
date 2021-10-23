using LibraryManagement.Domain.Common;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence
{
    public class LibraryManagementDbContext : DbContext
    {
        public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Library_Book> Libraries_Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementDbContext).Assembly);

            // seed data - added through migrations
            var library1 = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var library2 = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

            var book1 = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var book2 = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var author1 = Guid.Parse("{5FF453A0-4137-45DA-8C39-73B7CE261A0A}");
            var author2 = Guid.Parse("{DFA2168B-F0D6-4431-A8CA-77593F02D9F3}");

            var publisher1 = Guid.Parse("{AA1EBAC1-7A1C-4813-904F-1E79C7F1407F}");
            var publisher2 = Guid.Parse("{CD3DC7F2-21AB-4FAD-AED9-C9FFD7895F79}");

            var library_book1 = Guid.Parse("{2020C726-1E92-4E17-8678-F2E9F6C72CA6}");
            var library_book2 = Guid.Parse("{5B27DE0B-1626-41D2-8FB5-826936CB4F94}");

            var book_author1 = Guid.Parse("{0B592643-693E-499B-943D-45972DF52A4F}");
            var book_author2 = Guid.Parse("{7022632A-51FF-4048-9435-C909D74A41C1}");

            modelBuilder.Entity<Library>().HasData(
                new List<Library>()
                {
                    new Library
                        {
                            LibraryId = library1,
                            Name = "Fairfax County Public Library",
                            Location = "Virginia",
                            EstablishedDate = DateTime.Now.AddYears(-20)
                        },
                     new Library
                        {
                            LibraryId = library2,
                            Name = "Biblioteca Nacional de Chile",
                            Location = "Chile",
                            EstablishedDate = DateTime.Now.AddYears(-56)
                        }
                });

            modelBuilder.Entity<Book>().HasData(
                new List<Book>()
                {
                    new Book
                    {
                        BookId = book1,
                        Name = "The Hobbit",
                        Description = "The Hobbit",
                        Genre = "Fantasy",
                        DateAdded = DateTime.Now.AddYears(-15),
                        PulisherId = publisher1
                    },
                    new Book
                    {
                        BookId = book2,
                        Name = "Dream of the Red Chamber",
                        Description = "Dream of the Red Chamber",
                        Genre = "Drama",
                        DateAdded = DateTime.Now.AddYears(-43),
                        PulisherId = publisher2
                    }
                });

            modelBuilder.Entity<Author>().HasData(
                new List<Author>()
                {
                     new Author
                     {
                         AuthorId = author1,
                         FirstName = "Tolkien",
                         LastName = "J.R.R"
                     },
                     new Author
                     {
                         AuthorId = author2,
                         FirstName = "Xueqin",
                         LastName = "Cao"
                     }
                });

            modelBuilder.Entity<Publisher>().HasData(
                new List<Publisher>()
                {
                     new Publisher
                     {
                         PublisherId = publisher1,
                         Name = "Universal Pictures"
                     },
                     new Publisher
                     {
                         PublisherId = publisher2,
                         Name = "Warner Media"
                     }
                });

            modelBuilder.Entity<Library_Book>().HasData(
                new List<Library_Book>()
                {
                    new Library_Book
                    {
                        Id = library_book1,
                        BookId = book1,
                        LibraryId = library1
                    },
                     new Library_Book
                    {
                        Id = library_book2,
                        BookId = book2,
                        LibraryId = library2
                    }
                });

            modelBuilder.Entity<Book_Author>().HasData(
                new List<Book_Author>()
                {
                     new Book_Author
                     {
                         Id = book_author1,
                         BookId = book1,
                         AuthorId = author1
                     },
                     new Book_Author
                     {
                         Id = book_author2,
                         BookId = book2,
                         AuthorId = author2
                     }
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {                    
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
