using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Book>> GetAllBooksByAuthor(Guid authorId)
        {
            var books = await _dbContext.Books.Include(b => b.Authors).ToListAsync();
            /*var book_authors = await _dbContext.Books_Authors.Include(b => b.Author).ToListAsync();

            foreach (Book book in books)
            {
                book.Authors = book_authors.Where(ba => ba.BookId == book.BookId).ToList();
            }*/

            return books;
        }

        public async Task<List<Book>> GetAllBooksByGenre(string genre)
        {
            return await _dbContext.Books.Where(b => b.Genre == genre).ToListAsync();
        }

        public Task<bool> IsBookNameUnique(string name)
        {
            var result = _dbContext.Books.Any(b => b.Name == name);
            return Task.FromResult(result);
        }
    }
}
