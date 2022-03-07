using Evona.Task.Application.Responses;
using MediatR;

namespace Evona.Task.Application.Features.Students.Requests.Commands
{
    public class GenerateStudentsCommand : IRequest<BaseCommandResponse>
    {
        public int NumberOfStudents { get; set; }
    }
}
