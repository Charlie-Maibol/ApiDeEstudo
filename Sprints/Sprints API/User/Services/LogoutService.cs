using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace UserAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser()
        {
            var identityResult = _signInManager.SignOutAsync();
            if (identityResult.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Erro ao realizar logout");
        }
    }
}
