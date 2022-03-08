using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.Features.Students.Requests.Commands;
using Evona.Task.Application.Features.Students.Requests.Queries;
using Evona.Task.Application.Responses;
using Evona.Task.Identity.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Evona.Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<StudentDto>>> Get([FromQuery] StudentSearchDto search)
        {
            var students = await _mediator.Send(new GetStudentListRequest() { Search = search });
            return Ok(students);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var student = await _mediator.Send(new GetStudentDetailsRequest { Id = id });
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = UserRoles.AdminRole)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateStudentDto student)
        {
            var response = await _mediator.Send(new CreateStudentCommand { Student = student });
            return Ok(response);
        }

        [HttpPost("GenerateStudents")]
        [Authorize(Roles = UserRoles.AdminRole)]
        public async Task<ActionResult<BaseCommandResponse>> GenerateStudents(int numberOfStudents)
        {
            var response = await _mediator.Send(new GenerateStudentsCommand { NumberOfStudents = numberOfStudents });
            return Ok(response);
        }

        [HttpPost("Backup")]
        [Authorize(Roles = UserRoles.AdminRole)]
        public async Task<ActionResult<DefaultResponse>> Backup()
        {
            var response = await _mediator.Send(new BackupStudentCommand());
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.AdminRole)]
        public async Task<ActionResult> Put([FromBody] StudentDto student)
        {
            await _mediator.Send(new UpdateStudentCommand { Student = student });
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.AdminRole)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteStudentCommand { Id = id });
            return NoContent();
        }
    }
}
