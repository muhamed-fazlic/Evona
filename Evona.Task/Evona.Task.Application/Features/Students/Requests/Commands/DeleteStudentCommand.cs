using MediatR;

namespace Evona.Task.Application.Features.Students.Requests.Commands
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
