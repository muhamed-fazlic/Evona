using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.StudentBackup;
using Evona.Task.Application.Exceptions;
using Evona.Task.Application.Features.StudentsBackup.Request.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.StudentsBackup.Handlers.Queries
{
    public class GetStudentBackupDetailsRequestHandler : IRequestHandler<GetStudentBackupDetailsRequest, StudentBackupDto>
    {
        private readonly IStudentBackupRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentBackupDetailsRequestHandler(IStudentBackupRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentBackupDto> Handle(GetStudentBackupDetailsRequest request, CancellationToken cancellationToken)
        {
            var Student = await _studentRepository.Get(request.Id);

            if (Student is null)
                throw new NotFoundException(nameof(Student), request.Id);

            return _mapper.Map<StudentBackupDto>(Student);
        }
    }
}
