using System.Buffers;
using Microsoft.AspNetCore.Mvc;

namespace CovidApp
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Authenticate(LoginDTO model)
        {
            var response = _loginService.Authenticate(model);
            if (response == null)
                return BadRequest(new { message = "Phone number is incorrect" });
            return Ok(response);
        }
    }
}