using Microsoft.AspNetCore.Mvc;
using VeracidataApi.Application.Interfaces;
using VeracidataApi.Application.Models.Requests;
using VeracidataApi.Application.Models.Responses;

namespace VeracidataApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<long>> Register([FromBody] RegisterRequest request)
        {
            var id = await _authService.RegisterAsync(request);
            return CreatedAtAction(null, new { id }, id);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
        {
            var auth = await _authService.LoginAsync(request);
            if (auth == null)
                return Unauthorized(new { Message = "Invalid email or password." });

            return Ok(auth);
        }
    }
}
