using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsPublisherNameUnique(string name)
        {
            var matches = _dbContext.Publishers.Any(p => p.Name.ToLower() == name.ToLower());
            return Task.FromResult(matches);
        }
    }
}
