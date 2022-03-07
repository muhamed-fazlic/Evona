using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student.Validators;
using Evona.Task.Application.Exceptions;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Commands
{
    public class GenerateStudentsCommandHandler : IRequestHandler<GenerateStudentsCommand, BaseCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GenerateStudentsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(GenerateStudentsCommand request, CancellationToken cancellationToken)
        {
            var validator = new GenerateStudentsValidator();
            var validationResult = await validator.ValidateAsync(request.NumberOfStudents, cancellationToken);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            await _unitOfWork.StudentRepository.GenerateStudents(request.NumberOfStudents);
            await _unitOfWork.Save();

            return new BaseCommandResponse { Success = true, Message = "Creation Successful" };
        }
    }
}
