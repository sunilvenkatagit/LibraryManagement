using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsAuthorNameUnique()
        {
            throw new NotImplementedException();
        }
    }
}
