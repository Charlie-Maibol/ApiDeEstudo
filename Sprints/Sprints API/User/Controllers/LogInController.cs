﻿using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        public LogInService _logInService;

        public LogInController(LogInService logInService)
        {
            _logInService = logInService;
        }

        [HttpPost]
        public IActionResult LogInUser(LoginRequest request)
        {
            
            Result result = _logInService.LogInUser(request);
            if(result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault()); 
            return Ok(result.Successes.FirstOrDefault());
        }
        [HttpPost("/Reset")]
        [Authorize(Roles = "admin")]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            Result result = _logInService.ResetPassword(resetPassword);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());

        }

    }
}
