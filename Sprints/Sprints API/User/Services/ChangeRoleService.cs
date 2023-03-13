using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class ChangeRoleService
    {

        public SignInManager<CustomIdentityUser> _signInManager;
        public ChangeRoleService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
        }
        public Result ChangeRole(ChangeRoleRequest request )
        {
            var user = _signInManager.UserManager.FindByEmailAsync(request.Email).Result;
            if (user == null)
            {
                return Result.Fail("Falha ao alterar usuário");

            }

            var client = _signInManager.UserManager.IsInRoleAsync(user, "regular");
            if (client.Result == true)
            {
                return Result.Fail("Alteração de permissão não autorizada para esse usuário");
            }

            var changeRole = _signInManager.UserManager.AddToRoleAsync(user, request.Role).Result;
            return Result.Ok();
        }
    }
}
