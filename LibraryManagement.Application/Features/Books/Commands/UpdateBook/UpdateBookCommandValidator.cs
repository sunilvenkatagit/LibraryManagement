using FluentValidation;
using LibraryManagement.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(b => b.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(b => b.Genre)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(b => b.DateAdded)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(b => b.PublisherId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(b => b.AuthorIds)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(b => b.LibraryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(b => b)
                .MustAsync(BookNameUnique)
                .WithMessage("A book with the same name exists already.");
        }

        private async Task<bool> BookNameUnique(UpdateBookCommand b, CancellationToken token)
        {
            return !(await _bookRepository.IsBookNameUnique(b.Name));
        }
    }
}
