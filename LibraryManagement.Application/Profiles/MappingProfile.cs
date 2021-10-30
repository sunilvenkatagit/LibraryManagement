using AutoMapper;
using LibraryManagement.Application.Features.Books.Commands.CreateBook;
using LibraryManagement.Application.Features.Books.Commands.UpdateBook;
using LibraryManagement.Application.Features.Books.Queries.GetBooksByGenre;
using LibraryManagement.Application.Features.Libraries.Commands.CreateLibrary;
using LibraryManagement.Application.Features.Libraries.Commands.DeleteLibrary;
using LibraryManagement.Application.Features.Libraries.Commands.UpdateLibrary;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesByLocation;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesList;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Library, LibraryListVm>().ReverseMap();
            CreateMap<Library, LibraryListLocationVm>().ReverseMap();
            CreateMap<Library, LibraryBookListVm>().ReverseMap();
            CreateMap<Library, CreateLibraryCommand>().ReverseMap();
            CreateMap<Library, UpdateLibraryCommand>().ReverseMap();
            CreateMap<Library, DeleteLibraryCommand>().ReverseMap();
            CreateMap<Book, LibraryBookDto>().ReverseMap();

            CreateMap<Book, BookListGenreVm>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();
        }
    }
}
