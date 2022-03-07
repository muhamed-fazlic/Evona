using Evona.Task.Application.DTOs.Student;
using MediatR;

namespace Evona.Task.Application.Features.Students.Requests.Commands
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public StudentDto Student { get; set; }
    }
}
