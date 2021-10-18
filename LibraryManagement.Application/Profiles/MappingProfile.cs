using AutoMapper;
using LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesList;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Library, LibraryListVm>().ReverseMap();
        }
    }
}
