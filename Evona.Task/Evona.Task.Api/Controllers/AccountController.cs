using Evona.Task.Application.Contracts.Identity;
using Evona.Task.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Evona.Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        //Commented because the logic in the register will be implemented, now it returns only NotImplementedException because it's not a necessary task
        //[HttpPost("Register")]
        //public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        //{
        //    return Ok(await _authService.Register(request));
        //}
    }
}
