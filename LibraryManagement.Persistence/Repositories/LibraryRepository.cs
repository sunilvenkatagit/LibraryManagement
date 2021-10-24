using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repositories
{
    public class LibraryRepository : BaseRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Library>> GetLibrariesByLocation(string location, int page, int size)
        {
            return await _dbContext.Libraries.Where(lb => lb.Location == location)
                                             .Skip((page - 1) * size)
                                             .Take(size)
                                             .AsNoTracking()
                                             .ToListAsync();
        }

        public async Task<List<Library>> GetLibrariesWithBooks()
        {
            var libraries = await _dbContext.Libraries.Include(lb => lb.Books).ToListAsync();
            /*var library_books = await _dbContext.Libraries_Books.Include(lb => lb.Book).ToListAsync();

            foreach (var library in libraries)
            {
                library.Books = library_books.Where(lb => lb.LibraryId == library.LibraryId).ToList();
            }*/

            return libraries;
        }

        public Task<bool> IsLibraryNameUnique(string name)
        {
            var result = _dbContext.Libraries.Any(lb => lb.Name == name);
            return Task.FromResult(result);
        }
    }
}
