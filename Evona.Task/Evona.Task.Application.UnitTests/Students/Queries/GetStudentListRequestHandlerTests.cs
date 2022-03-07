using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.Features.Students.Handlers.Queries;
using Evona.Task.Application.Features.Students.Requests.Queries;
using Evona.Task.Application.Profiles;
using Evona.Task.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Evona.Task.Application.UnitTests.Students.Queries
{
    public class GetStudentListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStudentRepository> _mockRepo;
        public GetStudentListRequestHandlerTests()
        {
            _mockRepo = MockStudentRepository.GetStudentRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetStudentListTest()
        {

            var handler = new GetStudentListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetStudentListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<StudentDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
