using AutoMapper;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using LibraryManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommandHanlder : IRequestHandler<CreatePublisherCommand, Guid>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public CreatePublisherCommandHanlder(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePublisherCommandValidator(_publisherRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var @publisher = _mapper.Map<Publisher>(request);
            @publisher = await _publisherRepository.AddAsync(@publisher);

            return @publisher.PublisherId;
        }
    }
}
