using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagement.API.Helpers;
using StudentManagement.API.Models;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            JwtHelper jwtHelper,
            ILogger<AuthController> logger)
        {
            _jwtHelper = jwtHelper;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (request.Username != "admin" || request.Password != "admin123")
            {
                _logger.LogWarning("Failed login attempt for user {Username}", request.Username);

                return Unauthorized(new
                {
                    message = "Invalid username or password"
                });
            }

            var token = _jwtHelper.GenerateToken(request.Username);

            _logger.LogInformation("User {Username} logged in successfully", request.Username);

            return Ok(new
            {
                token
            });
        }
    }
}