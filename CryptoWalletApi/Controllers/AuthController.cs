namespace CryptoWalletApi.Controllers
{
    using CryptoWalletApi.DTOs;
    using CryptoWalletApi.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var success = await _userService.RegisterAsync(dto);
            if (!success) return BadRequest("Email already registered.");
            return Ok("User created.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            if (token == null) return Unauthorized("Invalid credentials.");
            return Ok(new { token });
        }
    }
}
