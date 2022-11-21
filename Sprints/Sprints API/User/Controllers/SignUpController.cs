
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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

        //[HttpGet("filter")]
        //[Authorize(Roles = "admin, regular")]
        //public async Task<IActionResult> GetUserId([FromQuery] int id)
        //{
        //    var result = await _signUpService.GetUserId(id);
        //    return Ok(result);
           
        //}
        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> GetUser([FromQuery] string name,
            [FromQuery] string cpf, [FromQuery] string email, [FromQuery] bool? status)
        {
            var result = await _signUpService.GetUser(name, cpf, status, email);
            return Ok(result);
        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUser(int Id, [FromBody] EditUserDto userDto)
        {
            var result = await _signUpService.EditUser(Id, userDto);
            if (!result.IsSuccess) return StatusCode(400);
            return Ok(result);
        }

     

    }
}
