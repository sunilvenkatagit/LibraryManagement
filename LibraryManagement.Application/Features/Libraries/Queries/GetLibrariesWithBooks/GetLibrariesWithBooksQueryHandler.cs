using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Queries.GetLibrariesWithBooks
{
    public class GetLibrariesWithBooksQueryHandler : IRequestHandler<GetLibrariesWithBooksQuery, List<LibraryBookListVm>>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibrariesWithBooksQueryHandler(IMapper mapper, ILibraryRepository libraryRepository)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
        }

        public async Task<List<LibraryBookListVm>> Handle(GetLibrariesWithBooksQuery request, CancellationToken cancellationToken)
        {
            var librariesWithBooks = await _libraryRepository.GetLibrariesWithBooks();
            return _mapper.Map<List<LibraryBookListVm>>(librariesWithBooks);
        }
    }
}
