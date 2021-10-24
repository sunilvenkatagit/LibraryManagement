using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Commands.UpdateLibrary
{
    public class UpdateLibraryCommandHandler : IRequestHandler<UpdateLibraryCommand>
    {
        private readonly IAsyncRepository<Library> _libraryRepository;
        private readonly IMapper _mapper;

        public UpdateLibraryCommandHandler(IAsyncRepository<Library> libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
        {
            var libraryToUpdate = await _libraryRepository.GetByIdAsync(request.LibraryId);
            if (libraryToUpdate == null)
            {
                throw new NotFoundException(nameof(Library), request.LibraryId);
            }

            var validator = new UpdateLibraryCommandValidator();
            var validationresult = await validator.ValidateAsync(request);
            if (validationresult.Errors.Count > 0)
            {
                throw new ValidationException(validationresult);
            }

            _mapper.Map(request, libraryToUpdate, typeof(UpdateLibraryCommand), typeof(Library));
            await _libraryRepository.UpdateAsync(libraryToUpdate);

            return Unit.Value;
        }
    }
}
