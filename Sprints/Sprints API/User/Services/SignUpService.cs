using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UserAPI.Data.DTOs;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class SignUpService
    {
        public IMapper _mapper;
        public UserManager<IdentityUser<int>> _userManager;

        public SignUpService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result signUpUser(CreateUserDTO createDto)
        {
            Users user = _mapper.Map<Users>(createDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> identityResult = _userManager.CreateAsync(identityUser, createDto.PassWord);
            if (identityResult.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}
