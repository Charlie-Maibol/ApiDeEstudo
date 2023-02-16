using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers0
{

    [Route("[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private SignUpService _signUpService;

        public SignUpController(SignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        [HttpPost]
        public IActionResult SignUpUser(CreateUserDTO createDto)
        {
            Result result = _signUpService.signUpUser(createDto);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }

        [HttpGet("/confirm")]
        public IActionResult ConfirmUser([FromQuery] ConfirmUserRequest request)
        {
            Result result = _signUpService.ConfirmUser(request);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }
    }
}
