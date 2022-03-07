using Evona.Task.Application.DTOs.Student;
using Evona.Task.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evona.Task.Application.Contracts.Persistence
{
    public interface IStudentRepository : IGenericRepository<Student, StudentSearchDto>
    {
        Task<bool> GenerateStudents(int NumberOfStudents);
        public Task<List<Student>> UpdateAll();
    }
}