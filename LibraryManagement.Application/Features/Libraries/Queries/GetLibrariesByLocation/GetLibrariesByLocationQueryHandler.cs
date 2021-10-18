using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesByLocation
{
    public class GetLibrariesByLocationQueryHandler : IRequestHandler<GetLibrariesByLocationQuery, List<LibraryListLocationVm>>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibrariesByLocationQueryHandler(IMapper mapper, ILibraryRepository libraryRepository)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
        }

        public async Task<List<LibraryListLocationVm>> Handle(GetLibrariesByLocationQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _libraryRepository.GetLibrariesByLocation(request.Location, page: 1, size: 5);
            return _mapper.Map<List<LibraryListLocationVm>>(libraries);
        }
    }
}
