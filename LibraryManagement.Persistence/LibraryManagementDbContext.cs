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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementDbContext).Assembly);

            // seed data - added through migrations
            var libraryId1 = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var libraryId2 = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

            var authorId1 = Guid.Parse("{5FF453A0-4137-45DA-8C39-73B7CE261A0A}");
            var authorId2 = Guid.Parse("{DFA2168B-F0D6-4431-A8CA-77593F02D9F3}");

            var publisherId1 = Guid.Parse("{AA1EBAC1-7A1C-4813-904F-1E79C7F1407F}");
            var publisherId2 = Guid.Parse("{CD3DC7F2-21AB-4FAD-AED9-C9FFD7895F79}");

            var bookId1 = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var bookId2 = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Library>().HasData(
                new List<Library>()
                {
                    new Library
                        {
                            LibraryId = libraryId1,
                            Name = "Fairfax County Public Library",
                            Location = "Virginia",
                            EstablishedDate = DateTime.Now.AddYears(-20)
                        },
                     new Library
                        {
                            LibraryId = libraryId2,
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
                            BookId = bookId1,
                            Name = "The Hobbit",
                            Description = "The Hobbit",
                            Genre = "Fantasy",
                            DateAdded = DateTime.Now.AddYears(-15),
                            PublisherId = publisherId1,
                            LibraryId = libraryId1
                        },
                    new Book
                        {
                            BookId = bookId2,
                            Name = "Dream of the Red Chamber",
                            Description = "Dream of the Red Chamber",
                            Genre = "Drama",
                            DateAdded = DateTime.Now.AddYears(-43),
                            PublisherId = publisherId2,
                            LibraryId = libraryId2
                        }
                });

            modelBuilder.Entity<Author>().HasData(
                new List<Author>()
                {
                     new Author { AuthorId = authorId1, FirstName = "Tolkien", LastName = "J.R.R" },
                     new Author { AuthorId = authorId2, FirstName = "Xueqin", LastName = "Cao" }
                });

            modelBuilder.Entity<Publisher>().HasData(
                new List<Publisher>()
                {
                     new Publisher
                     {
                         PublisherId = publisherId1,
                         Name = "Universal Pictures"
                     },
                     new Publisher
                     {
                         PublisherId = publisherId2,
                         Name = "Warner Media"
                     }
                });

            modelBuilder.Entity<Book>()
                 .HasMany(b => b.Authors)
                 .WithMany(a => a.Books)
                 .UsingEntity<Dictionary<string, object>>(
                     "BookAuthor",
                     r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                     l => l.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                     je =>
                     {
                         je.HasKey("BookId", "AuthorId");
                         je.HasData(
                             new { BookId = bookId1, AuthorId = authorId1 },
                             new { BookId = bookId2, AuthorId = authorId2 });
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
