using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.Exceptions;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Domain;
using Evona.Task.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentRepository.Get(request.Id);

            if (student == null)
                throw new NotFoundException(nameof(Student), request.Id);

           _unitOfWork.StudentRepository.Delete(student);
            var backupStudent = await _unitOfWork.StudentBackupRepository.Get(request.Id);
            if(backupStudent!=null)
                backupStudent.BackupStatus = BackupStatuses.Deleted;
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
