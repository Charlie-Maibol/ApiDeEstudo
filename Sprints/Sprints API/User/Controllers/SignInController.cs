using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;

namespace UserAPI.Controllers
{

    [Route("[controller")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        [HttpPost]
        public IActionResult SignInUser(CreateUserDTO createDto)
        {
            return Ok();
        }
    }
}
