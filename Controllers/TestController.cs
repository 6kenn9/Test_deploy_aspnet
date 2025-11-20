using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InstrumentRentalApi.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok("Це ВІДКРИТИЙ ендпойнт. Всіх пускають.");
        }

        [Authorize] 
        [HttpGet("private")]
        public IActionResult PrivateEndpoint()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return Ok($"Це ЗАКРИТИЙ ендпойнт! Тебе пустило. Твій Email: {userEmail}, Твій ID: {userId}");
        }
    }
}