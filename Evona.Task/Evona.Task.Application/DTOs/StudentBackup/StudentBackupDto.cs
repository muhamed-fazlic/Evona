using Evona.Task.Application.DTOs.Common;
using System;

namespace Evona.Task.Application.DTOs.StudentBackup
{
    public class StudentBackupDto : BaseDto
    {
        public int IdFromStudentTable { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
