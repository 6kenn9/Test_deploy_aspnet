using Microsoft.AspNetCore.Mvc;
using InstrumentRentalApi.Models;
using InstrumentRentalApi.Services;
using System.Threading.Tasks;

namespace InstrumentRentalApi.Controllers 
{
    public class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class RegisterModel
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;
        public AuthController(
            IUserService userService,
            JwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var existingUser = await _userService.GetByEmailAsync(model.Email);
            if (existingUser != null)
                return BadRequest("Користувач з такою поштою вже існує.");
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = _passwordHasher.HashPassword(model.Password)
            };

            await _userService.CreateAsync(user);

            return Ok(new { message = "Користувач успішно зареєстрований." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.GetByEmailAsync(model.Email);
            if (user == null || user.PasswordHash == null)
                return Unauthorized("Неправильна пошта або пароль."); 

            if (!_passwordHasher.Verify(model.Password, user.PasswordHash))
                return Unauthorized("Неправильна пошта або пароль."); 

            var token = _jwtTokenGenerator.Generate(user);

            return Ok(new
            {
                Token = token
            });
        }
    }
}