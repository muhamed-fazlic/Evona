using AutoMapper;
using Evona.Task.Application.Contracts.Infrastructure;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student.Validators;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Application.Models.Emails;
using Evona.Task.Application.Responses;
using Evona.Task.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Evona.Task.Application.Features.Students.Handlers.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateStudentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Student, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var student = _mapper.Map<Student>(request.Student);
                student = await _unitOfWork.StudentRepository.Add(student);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = student.Id;

                var email = new Email
                {
                    To = "m.fazlic4@gmail.com",
                    Body = $"Your Student {student.FirstName} {student.LastModifiedBy} has been submitted successfully",
                    Subject = "Student Request Submitted"
                };
                try
                {
                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                {
                    //Log or handle error, but don't throw.
                    Console.WriteLine(ex.Message);
                }
            }
            return response;
        }
    }
}
