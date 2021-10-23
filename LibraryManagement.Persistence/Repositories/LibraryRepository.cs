using LibraryManagement.Application.Contracts.Persistence;
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
            return await _dbContext.Libraries.Include(lb => lb.Books).ToListAsync();
        }

        public Task<bool> IsLibraryNameUnique(string name)
        {
            var result = _dbContext.Libraries.Any(lb => lb.Name == name);
            return Task.FromResult(result);
        }
    }
}
