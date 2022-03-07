using Evona.Task.Application.DTOs.Common;
using System;

namespace Evona.Task.Application.DTOs.Student
{
    public class StudentDto : BaseDto, IStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
