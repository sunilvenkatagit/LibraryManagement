using LibraryManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<Book> GetAllBooksByLibrary(Guid libraryId);
        Task<Book> GetAllBooksByGenre(string genre);
        Task<Book> GetAllBooksByAuthor(Guid authorId);
        Task<Book> GetAllBooksByPublihser(Guid publisherId);
        Task<bool> IsBookNameUnique();
    }
}
