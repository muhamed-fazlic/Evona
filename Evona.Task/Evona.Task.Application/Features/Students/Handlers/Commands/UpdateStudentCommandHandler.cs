using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student.Validators;
using Evona.Task.Application.Exceptions;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStudentDtoValidator(_unitOfWork.StudentRepository);
            var validationResult = await validator.ValidateAsync(request.Student);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var student = await _unitOfWork.StudentRepository.Get(request.Student.Id);

            if (student is null)
                throw new NotFoundException(nameof(student), request.Student.Id);

            _mapper.Map(request.Student, student);
            student.BackupStatus = BackupStatuses.Updated;
            _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
