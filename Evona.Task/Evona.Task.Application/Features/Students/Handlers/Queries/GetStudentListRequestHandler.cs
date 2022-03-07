using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.Features.Students.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Queries
{
    public class GetStudentListRequestHandler : IRequestHandler<GetStudentListRequest, List<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListRequestHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentDto>> Handle(GetStudentListRequest request, CancellationToken cancellationToken)
        {
            var Students = await _studentRepository.GetAll(request.Search);
            return _mapper.Map<List<StudentDto>>(Students);
        }
    }
}
