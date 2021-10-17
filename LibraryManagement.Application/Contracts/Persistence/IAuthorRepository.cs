using LibraryManagement.Domain.Entities;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface IAuthorRepository : IAsyncRepository<Author>
    {
        Task<bool> IsAuthorNameUnique();
    }
}
