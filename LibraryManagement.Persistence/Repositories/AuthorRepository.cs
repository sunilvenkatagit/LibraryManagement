using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsAuthorNameUnique(string name)
        {
            var result = _dbContext.Authors.Any(a => a.FirstName.ToLower() + a.LastName.ToLower() == name.ToLower());
            return Task.FromResult(result);
        }
    }
}
