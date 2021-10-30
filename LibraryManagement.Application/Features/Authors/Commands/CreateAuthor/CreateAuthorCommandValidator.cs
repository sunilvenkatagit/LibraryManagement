using FluentValidation;
using LibraryManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(a => a)
                .MustAsync(AuthorNameUnique)
                .WithMessage("An author exists with the same name");
        }

        public async Task<bool> AuthorNameUnique(CreateAuthorCommand a, CancellationToken token)
        {
            return !(await _authorRepository.IsAuthorNameUnique($"{a.FirstName + a.LastName}"));
        }
    }
}
