using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.DTOs.StudentBackup;
using MediatR;
using System.Collections.Generic;

namespace Evona.Task.Application.Features.StudentsBackup.Request.Queries
{
    public class GetStudentBackupListRequest : IRequest<List<StudentBackupDto>>
    {
        public StudentSearchDto Search { get; set; }
    }
}
