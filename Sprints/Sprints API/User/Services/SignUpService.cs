using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
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
        public UserManager<CustomIdentityUser> _userManager;
        public EmailService _emailService;

        public SignUpService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _emailService = emailService;
        }

        public Result signUpUser(CreateUserDTO createDto)
        {
            var logIn = GetAdress(createDto.ZipCode).Result;
            if (logIn != null)
            {
                Users user = _mapper.Map<Users>(createDto);
                user.Street = logIn.Street;
                user.Neighborhood = logIn.Neighborhood;
                user.UF = logIn.UF;
                user.City = logIn.City;
                CustomIdentityUser identityUser = _mapper.Map<CustomIdentityUser>(user);
                Task<IdentityResult> identityResult = _userManager.CreateAsync(identityUser, createDto.PassWord);
                if (identityResult.Result.Succeeded)
                {
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                    var encodedCode = HttpUtility.UrlEncode(code);
                    _emailService.SendEmail(new[] { identityUser.Email },
                        "Link de Ativação", identityUser.Id, encodedCode);
                    return Result.Ok().WithSuccess(code);
                }
                if (!identityResult.Result.Succeeded)
                {
                    return Result.Fail("Falha ao cadastrar usuário");
                }

            }
            return Result.Ok();

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
        public async Task<Users> GetAdress(string cep)
        {
            HttpClient client = new HttpClient();
            var requisition = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var json = await requisition.Content.ReadAsStringAsync();
            Users user = new();
            var viacep = JsonConvert.DeserializeObject<ViaCepDto>(json);
            CopyAddressToUser(user, viacep);
            return user;

        }
        private static void CopyAddressToUser(Users user, ViaCepDto viacep)
        {
            user.ZipCode = viacep.cep;
            user.Street = viacep.logradouro;
            user.UF = viacep.uf;
            user.Neighborhood = viacep.bairro;
            user.City = viacep.localidade;

        }
    }
}
