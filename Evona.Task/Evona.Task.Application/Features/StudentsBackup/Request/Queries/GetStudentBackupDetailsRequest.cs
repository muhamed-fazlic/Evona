using Evona.Task.Application.DTOs.StudentBackup;
using MediatR;

namespace Evona.Task.Application.Features.StudentsBackup.Request.Queries
{
    public class GetStudentBackupDetailsRequest : IRequest<StudentBackupDto>
    {
        public int Id { get; set; }
    }
}
