using Evona.Task.Application.DTOs.StudentBackup;
using Evona.Task.Application.Features.StudentsBackup.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evona.Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBackupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentBackupController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<StudentBackupDto>>> Get([FromQuery] object search)
        {
            var students = await _mediator.Send(new GetStudentBackupListRequest());
            return Ok(students);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<StudentBackupDto>> Get(int id)
        {
            var student = await _mediator.Send(new GetStudentBackupDetailsRequest { Id = id });
            return Ok(student);
        }
    }
}
