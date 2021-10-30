using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
