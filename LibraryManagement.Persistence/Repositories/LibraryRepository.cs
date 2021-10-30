using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<List<Library>> GetAllLibrariesByLocation(string location, int page, int size)
        {
            return await _dbContext.Libraries.Where(lb => lb.Location == location)
                                             .Skip((page - 1) * size)
                                             .Take(size)
                                             .AsNoTracking()
                                             .ToListAsync();
        }

        public async Task<List<Library>> GetLibraryWithBooks(Guid libraryId)
        {
            var libraries = await _dbContext.Libraries.Where(l => l.LibraryId == libraryId).Include(lb => lb.Books).ToListAsync();

            return libraries;
        }

        public Task<bool> IsLibraryNameUnique(string name)
        {
            var result = _dbContext.Libraries.Any(lb => lb.Name == name);
            return Task.FromResult(result);
        }
    }
}
