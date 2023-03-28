using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private ChangeRoleService _roleService;

        public RoleController(ChangeRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult ChangeRoleToAdm(ChangeRoleRequest request)
        {
            Result result = _roleService.ChangeRole(request);
            if (result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }


    }
}
