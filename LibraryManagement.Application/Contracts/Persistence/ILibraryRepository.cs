using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface ILibraryRepository : IAsyncRepository<Library>
    {
        Task<List<Library>> GetAllLibrariesByLocation(string location, int page, int size);
        Task<List<Library>> GetLibraryWithBooks(Guid libraryId);
        Task<bool> IsLibraryNameUnique(string name);
    }
}
