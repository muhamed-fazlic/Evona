using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.StudentBackup;
using Evona.Task.Application.Features.StudentsBackup.Request.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.StudentsBackup.Handlers.Queries
{
    public class GetStudentBackupListRequestHandler : IRequestHandler<GetStudentBackupListRequest, List<StudentBackupDto>>
    {
        private readonly IStudentBackupRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentBackupListRequestHandler(IStudentBackupRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentBackupDto>> Handle(GetStudentBackupListRequest request, CancellationToken cancellationToken)
        {
            var Students = await _studentRepository.GetAll();
            return _mapper.Map<List<StudentBackupDto>>(Students);
        }
    }
}
