
using FluentResults;
using Microsoft.AspNetCore.Authorization;
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
            return Ok();
        }

        
        [HttpGet("filter")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetUserId(SearchUserDto searchDto)
        {
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetUser(SearchUserDto searchDto)
        {
            
            return Ok();
        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "admin")]
        public IActionResult EditUser(EditUserDto editDto)
        {
            
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteUser(CreateUserDTO deleteDto)
        {
            
            return Ok();
        }

    }
}
