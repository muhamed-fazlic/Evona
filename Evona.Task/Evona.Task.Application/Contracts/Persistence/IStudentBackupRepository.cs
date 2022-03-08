using Evona.Task.Application.DTOs.Student;
using Evona.Task.Domain;

namespace Evona.Task.Application.Contracts.Persistence
{
    public interface IStudentBackupRepository : IGenericRepository<StudentBackup, StudentSearchDto>
    {
    }
}
