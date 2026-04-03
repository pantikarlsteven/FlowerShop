using FlowerShop.Application.DTOs;
using FlowerShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwt;
        private readonly IAuthService _authService;

        public AuthController(IJwtService jwt, IAuthService authService)
        {
            _jwt = jwt;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {

            var user = await _authService.Login(dto);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized();

            var token = _jwt.Generate(user);

            return Ok(new { token });
        }
    }
}