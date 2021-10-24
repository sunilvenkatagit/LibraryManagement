using FluentValidation;
using LibraryManagement.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Libraries.Commands.CreateLibrary
{
    public class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
    {
        private readonly ILibraryRepository _libraryRepository;

        public CreateLibraryCommandValidator(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;

            // Create rules
            RuleFor(lb => lb.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName must not exceed 50 characters.}");

            RuleFor(lb => lb.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName must not exceed 50 characters.}");

            RuleFor(lb => lb.EstablishedDate)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(lb => lb)
                .MustAsync(LibraryNameUnique)
                .WithMessage("A librray with the same name exists already.");            
        }

        private async Task<bool> LibraryNameUnique(CreateLibraryCommand lb, CancellationToken token)
        {
            //TODO Add comments here!
            return !(await _libraryRepository.IsLibraryNameUnique(lb.Name));
        }
    }
}
