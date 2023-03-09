
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class LogInService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;
        public LogInService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogInUser(LoginRequest request)
        {
            var user = _signInManager.UserManager.FindByEmailAsync(request.Email);
            var resultIdentity = _signInManager
                .PasswordSignInAsync(user.Result.UserName, request.PassWord, false, false);
            if (!resultIdentity.Result.Succeeded) 
            {
                return Result.Fail("Usuário e senhas incorretos");
            } 
            Token token = _tokenService
                .CreateToken(user.Result, _signInManager
                .UserManager.GetRolesAsync(user.Result)
                .Result.FirstOrDefault());
            return Result.Ok().WithSuccess(token.Value);
        }

        public Result ResetPassword(ResetPassword resetPassword)
        {
            var user = _signInManager.UserManager.FindByEmailAsync(resetPassword.Email).Result;
            var changePassword = _signInManager
                .UserManager
                .ChangePasswordAsync(user, resetPassword.Password, resetPassword.NewPassword)
                .Result;
            if (!changePassword.Succeeded)
            {
                return Result.Fail("Não foi possivel alterar a senha");
            }
            return Result.Ok(); 
                
        }
    }
}
