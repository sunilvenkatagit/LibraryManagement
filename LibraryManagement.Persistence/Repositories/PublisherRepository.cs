using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibraryManagementDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsPublisherNameUnique()
        {
            throw new NotImplementedException();
        }
    }
}
