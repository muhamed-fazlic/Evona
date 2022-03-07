﻿using System;

namespace Evona.Task.Application.DTOs.Student
{
    public interface IStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
