using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.Exceptions;
using Evona.Task.Application.Features.Students.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Queries
{
    public class GetStudentDetailsRequestHandler : IRequestHandler<GetStudentDetailsRequest, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentDetailsRequestHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentDetailsRequest request, CancellationToken cancellationToken)
        {
            var Student = await _studentRepository.Get(request.Id);

            if (Student is null)
                throw new NotFoundException(nameof(Student), request.Id);

            return _mapper.Map<StudentDto>(Student);
        }
    }
}
