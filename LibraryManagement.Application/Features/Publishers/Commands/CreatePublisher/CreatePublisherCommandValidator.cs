using FluentValidation;
using LibraryManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
    {
        private readonly IPublisherRepository _publisherRepository;

        public CreatePublisherCommandValidator(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p)
                .MustAsync(PublisherNameUnique)
                .WithMessage("A publisher with the same name exists already.");
        }

        private async Task<bool> PublisherNameUnique(CreatePublisherCommand p, CancellationToken token)
        {
            return !(await _publisherRepository.IsPublisherNameUnique(p.Name));
        }
    }
}
