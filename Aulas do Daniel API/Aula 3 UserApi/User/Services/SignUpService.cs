using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserAPI.Data.DTOs;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class SignUpService
    {
        public IMapper _mapper;
        public UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public SignUpService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result signUpUser(CreateUserDTO createDto)
        {
            Users user = _mapper.Map<Users>(createDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> identityResult = _userManager
                .CreateAsync(identityUser, createDto.PassWord);
            if (identityResult.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.SendEmail(new [] {identityUser.Email},
                    "Link de Ativação", identityUser.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
            
        }

        public Result ConfirmUser(ConfirmUserRequest request)
        {
            var IdentityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UserId);
            var identityResult = _userManager.ConfirmEmailAsync(IdentityUser, request.ActivationCode).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta");
        }
    }
}
