using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesList
{
    public class GetLibrariesListQueryHandler : IRequestHandler<GetLibrariesListQuery, List<LibraryListVm>>
    {
        private readonly IAsyncRepository<Library> _libraryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetLibrariesListQueryHandler> _logger;

        public GetLibrariesListQueryHandler(IMapper mapper, IAsyncRepository<Library> libraryRepository, ILogger<GetLibrariesListQueryHandler> logger)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _logger = logger;
        }

        public async Task<List<LibraryListVm>> Handle(GetLibrariesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all libraries");
            var allLibraries = (await _libraryRepository.LisAllAsync()).OrderBy(l => l.Name);
            return _mapper.Map<List<LibraryListVm>>(allLibraries);
        }
    }
}
