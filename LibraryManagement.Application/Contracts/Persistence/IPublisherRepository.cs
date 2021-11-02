using LibraryManagement.Domain.Entities;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface IPublisherRepository : IAsyncRepository<Publisher>
    {
        Task<bool> IsPublisherNameUnique(string name);
    }
}
