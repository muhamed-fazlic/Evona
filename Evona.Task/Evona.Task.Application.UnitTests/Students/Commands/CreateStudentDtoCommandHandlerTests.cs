using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.Features.Students.Handlers.Commands;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Application.Profiles;
using Evona.Task.Application.Responses;
using Evona.Task.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Threading;
using Xunit;

namespace Evona.Task.Application.UnitTests.Students.Commands
{
    public class CreateStudentDtoCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateStudentDto _CreateStudentDto;
        private readonly CreateStudentCommandHandler _handler;

        public CreateStudentDtoCommandHandlerTests()
        {
            _mockRepo = MockStudentUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateStudentCommandHandler(_mockRepo.Object, _mapper, null);

            _CreateStudentDto = new CreateStudentDto
            {
                FirstName = "Patricia",
                LastName = "Williams",
                JMBG = "1407911427827",
                BirthDate = new DateTime(2003, 04, 09)
            };
        }

        [Fact]
        public async System.Threading.Tasks.Task Valid_Student_Added()
        {
            var result = await _handler.Handle(new CreateStudentCommand() { Student = _CreateStudentDto }, CancellationToken.None);

            var students = await _mockRepo.Object.StudentRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            students.Count.ShouldBe(4);
        }

        [Fact]
        public async System.Threading.Tasks.Task InValid_Student_Added()
        {
            _CreateStudentDto.JMBG = "123"; //Must be 13 for: result.Message -> ("Creation Successful"), result.Succes -> true, result.Errors -> /

            var result = await _handler.Handle(new CreateStudentCommand() { Student = _CreateStudentDto }, CancellationToken.None);

            var students = await _mockRepo.Object.StudentRepository.GetAll();

            students.Count.ShouldBe(3);

            result.ShouldBeOfType<BaseCommandResponse>();
            Assert.Equal("Creation Failed", result.Message);
            Assert.False(result.Success);
            Assert.Contains("{PropertyJMBG} must have 13 characters.", result.Errors);
        }
    }
}
