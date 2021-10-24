using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<List<Book>> GetAllBooksByGenre(string genre);
        Task<bool> IsBookNameUnique(string name);
    }
}
