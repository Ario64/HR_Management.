using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var result = await _authService.Login(request);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var result = await _authService.Register(request);
            return Ok(result);
        }
    }
}
