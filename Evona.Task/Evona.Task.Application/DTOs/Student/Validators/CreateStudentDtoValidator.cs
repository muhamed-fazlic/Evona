using FluentValidation;

namespace Evona.Task.Application.DTOs.Student.Validators
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            Include(new IStudentDtoValidator());
        }
    }
}
