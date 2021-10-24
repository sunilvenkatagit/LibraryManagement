using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Commands.DeleteLibrary
{
    public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand>
    {
        private readonly IAsyncRepository<Library> _libraryRespository;
        private readonly IMapper _mapper;

        public DeleteLibraryCommandHandler(IAsyncRepository<Library> libraryRespository, IMapper mapper)
        {
            _libraryRespository = libraryRespository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
        {
            var libraryToDelete = await _libraryRespository.GetByIdAsync(request.LibraryId);

            if (libraryToDelete == null)
                throw new NotFoundException(nameof(Library), request.LibraryId);

            await _libraryRespository.DeleteAsync(libraryToDelete);

            return Unit.Value;
        }
    }
}
