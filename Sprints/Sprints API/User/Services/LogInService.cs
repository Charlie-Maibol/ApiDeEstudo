
using FluentResults;
using Microsoft.AspNetCore.Identity;
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
            var resultIdentity = _signInManager
                .PasswordSignInAsync(request.Email, request.PassWord, false, false);
            if (!resultIdentity.Result.Succeeded) 
            {
                return Result.Fail("Usuário e senhas incorretos");
            } 
            var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user =>
                    user.NormalizedUserName == request.Email.ToUpper());
            Token token = _tokenService.CreateToken(identityUser);
            return Result.Ok().WithSuccess(token.Value);
        }
    }
}
