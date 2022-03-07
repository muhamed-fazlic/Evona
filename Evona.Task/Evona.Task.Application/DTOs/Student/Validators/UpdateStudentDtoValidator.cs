using Evona.Task.Application.Contracts.Persistence;
using FluentValidation;

namespace Evona.Task.Application.DTOs.Student.Validators
{
    public class UpdateStudentDtoValidator : AbstractValidator<StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentDtoValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            Include(new IStudentDtoValidator());
            RuleFor(x => x.Id)
             .NotNull().WithMessage("{PropertyId} must be present.")
             .MustAsync(async (id, token) =>
             {
                 var StudentExist = await _studentRepository.Exists(id);
                 return StudentExist;
             }).WithMessage("{PropertyId} does not exist.");
        }
    }
}
