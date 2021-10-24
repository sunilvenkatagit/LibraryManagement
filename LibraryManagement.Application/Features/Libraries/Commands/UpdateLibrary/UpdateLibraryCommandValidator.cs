using FluentValidation;
using System;

namespace LibraryManagement.Application.Features.Libraries.Commands.UpdateLibrary
{
    public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
    {
        public UpdateLibraryCommandValidator()
        {
            RuleFor(lb => lb.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(lb => lb.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(lb => lb.EstablishedDate)
                .LessThanOrEqualTo(DateTime.Now);
        }
    }
}
