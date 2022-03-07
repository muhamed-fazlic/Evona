using Evona.Task.Application.DTOs.Student;
using MediatR;
using System.Collections.Generic;

namespace Evona.Task.Application.Features.Students.Requests.Queries
{
    public class GetStudentListRequest : IRequest<List<StudentDto>>
    {
        public StudentSearchDto Search { get; set; }
    }
}
