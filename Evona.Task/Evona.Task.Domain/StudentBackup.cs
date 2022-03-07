using Evona.Task.Domain.Common;
using System;

namespace Evona.Task.Domain
{
    public class StudentBackup : BaseDomainEntity
    {
        public int IdFromStudentTable { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate { get; set; }
        public string BackupStatus { get; set; }
    }
}
