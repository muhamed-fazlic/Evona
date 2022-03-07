using Evona.Task.Application.Contracts.Persistence;
using Moq;

namespace Evona.Task.Application.UnitTests.Mocks
{
    public class MockStudentUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockStudentRepo = MockStudentRepository.GetStudentRepository();

            mockUow.Setup(x => x.StudentRepository).Returns(mockStudentRepo.Object);

            return mockUow;
        }
    }
}
