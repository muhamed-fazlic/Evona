using FluentValidation;

namespace Evona.Task.Application.DTOs.Student.Validators
{
    public class GenerateStudentsValidator : AbstractValidator<int>
    {
        public GenerateStudentsValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("{Property - (NumberOfStudents)} value cannot be null.")
                .NotEmpty().WithMessage("{Property - (NumberOfStudents)} is required.")
                .GreaterThan(0).WithMessage("{Property - (NumberOfStudents)} must be greater than 0.")
                .LessThan(10000).WithMessage("{Property - (NumberOfStudents)} must be less than 50.000 per request.");
        }
    }
}
