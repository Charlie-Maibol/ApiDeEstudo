using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
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
