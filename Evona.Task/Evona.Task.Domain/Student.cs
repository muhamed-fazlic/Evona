using Evona.Task.Domain.Common;
using Evona.Task.Domain.Constants;
using System;

namespace Evona.Task.Domain
{
    public class Student : BaseDomainEntity
    {
        public Student()
        {
            BackupStatus = BackupStatuses.Created;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate { get; set; }
        public string BackupStatus { get; set; }
    }
}