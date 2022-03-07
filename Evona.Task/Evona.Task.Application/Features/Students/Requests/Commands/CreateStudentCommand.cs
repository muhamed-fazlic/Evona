using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.Responses;
using MediatR;

namespace Evona.Task.Application.Features.Students.Requests.Commands
{
    public class CreateStudentCommand : IRequest<BaseCommandResponse>
    {
        public CreateStudentDto Student { get; set; }
    }
}
