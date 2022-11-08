using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UserAPI.Data.Requests;

namespace UserAPI.Services
{
    public class LogInService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogInService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogInUser(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.PassWord, false, false);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("O logIn falhou!");
        }
    }
}
