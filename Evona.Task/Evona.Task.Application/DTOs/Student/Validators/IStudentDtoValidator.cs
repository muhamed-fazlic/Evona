using FluentValidation;
using System;

namespace Evona.Task.Application.DTOs.Student.Validators
{
    public class IStudentDtoValidator : AbstractValidator<IStudentDto>
    {
        public IStudentDtoValidator()
        {
            RuleFor(x => x.JMBG)
           .NotEmpty().WithMessage("{PropertyJMBG} is required.")
           .NotNull().WithMessage("{PropertyJMBG} value cannot be null.")
           .MaximumLength(13).WithMessage("{PropertyJMBG} must have 13 characters.")
           .MinimumLength(13).WithMessage("{PropertyJMBG} must have 13 characters.");

            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyFirstName} is required.")
            .NotNull().WithMessage("{PropertyFirstName} value cannot be null.")
            .MaximumLength(50).WithMessage("{PropertyFirstName} must not exceed 50 characters.");

            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyLastName} is required.")
            .NotNull().WithMessage("{PropertyLastName} value cannot be null.")
            .MaximumLength(50).WithMessage("{PropertyLastName} must not exceed 50 characters.");

            RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("{PropertyBirthDate} is required.")
            .NotNull().WithMessage("{PropertyBirthDate} value cannot be null.")
            .LessThan(DateTime.Now).WithMessage("{PropertyBirthDate} value must be before now.")
            .GreaterThan(new DateTime(1900, 01, 01)).WithMessage("{PropertyBirthDate} value must be after '01.01.1900'.");
        }
    }
}
