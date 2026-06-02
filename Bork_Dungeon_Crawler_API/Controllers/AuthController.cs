using Microsoft.AspNetCore.Mvc;
using Bork_Dungeon_Crawler_API.Services;

namespace Bork_Dungeon_Crawler_API.Controllers
{
    // Handles authentication endpoints (register + login)
    // This replaces the old Console MainMenu login system
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        // Dependency Injection: AuthService is provided by ASP.NET Core
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // REGISTER NEW USER
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // Try to create a new user via service
            var user = await _authService.Register(username, password);

            if (user == null)
            {
                // Username already exists
                return BadRequest(new
                {
                    message = "Username already taken"
                });
            }

            return Ok(new
            {
                message = "User created successfully",
                userId = user.Id,
                username = user.Username
            });
        }

        // LOGIN USER
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Try to authenticate user
            var user = await _authService.Login(username, password);

            if (user == null)
            {
                // Wrong credentials
                return Unauthorized(new
                {
                    message = "Invalid username or password"
                });
            }

            return Ok(new
            {
                message = "Login successful",
                userId = user.Id,
                username = user.Username
            });
        }
    }
}