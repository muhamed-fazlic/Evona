using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Domain;
using Moq;
using System;
using System.Collections.Generic;

namespace Evona.Task.Application.UnitTests.Mocks
{
    public static class MockStudentRepository
    {
        public static Mock<IStudentRepository> GetStudentRepository()
        {
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Smith",
                    JMBG = "1411955412829",
                    BirthDate = new DateTime(1999, 01, 01)
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jennifer",
                    LastName = "Williams",
                    JMBG = "1507911427827",
                    BirthDate = new DateTime(2000, 04, 09)
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Adam",
                    LastName = "Williams",
                    JMBG = "1507911427827",
                    BirthDate = new DateTime(2001, 04, 09)
                }
            };

            var mockRepo = new Mock<IStudentRepository>();

            mockRepo.Setup(x => x.GetAll(null)).ReturnsAsync(students);

            mockRepo.Setup(x => x.Add(It.IsAny<Student>())).ReturnsAsync((Student student) =>
            {
                students.Add(student);
                return student;
            });
            return mockRepo;
        }
    }
}
