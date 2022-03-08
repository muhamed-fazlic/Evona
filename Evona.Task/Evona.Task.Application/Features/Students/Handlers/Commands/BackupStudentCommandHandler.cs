using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Commands
{
    public class BackupStudentCommandHandler : IRequestHandler<BackupStudentCommand, DefaultResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BackupStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DefaultResponse> Handle(BackupStudentCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StudentRepository.UpdateAll();
            await _unitOfWork.Save();
            return new DefaultResponse { Success = true, Message = "Rows are updated!" };
        }
    }
}
