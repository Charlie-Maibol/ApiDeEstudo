
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class LogInService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LogInService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogInUser(LoginRequest request)
        {
            var resultIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.PassWord, false, false);
            if (resultIdentity.Result.Succeeded) 
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => 
                    user.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            } 
            return Result.Fail("O logIn falhou!");
        }
    }
}
