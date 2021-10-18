using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface ILibraryRepository : IAsyncRepository<Library>
    {
        Task<List<Library>> GetLibrariesByLocation(string location, int page, int size);
        Task<List<Library>> GetLibrariesWithBooks();
        Task<bool> IsLibraryNameUnique(string name);
    }
}
