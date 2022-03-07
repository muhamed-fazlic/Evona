using Evona.Task.Application.DTOs.Student;
using MediatR;

namespace Evona.Task.Application.Features.Students.Requests.Queries
{
    public class GetStudentDetailsRequest : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}
