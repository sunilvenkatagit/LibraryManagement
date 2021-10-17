using LibraryManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface ILibraryRepository : IAsyncRepository<Library>
    {
        Task<List<Library>> GetLibrariesByLocation(string location, int page = 1, int size = 5);
        Task<bool> IsLibraryNameUnique(string name);
    }
}
