using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using UserAPI.Data.DTOs;
using UserAPI.Models;
namespace UserAPI.Services
{
    public class SignUpService
    {
        public IMapper _mapper;
        public UserManager<CustomIdentityUser> _userManager;
        public RoleManager<IdentityRole<int>> _roleManager;


        public SignUpService(IMapper mapper, UserManager<CustomIdentityUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
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
                Task<IdentityResult> identityResult = _userManager
                    .CreateAsync(identityUser, createDto.PassWord);
                _userManager.AddToRoleAsync(identityUser, "regular");
                if (!identityResult.Result.Succeeded)
                {
                    return Result.Fail("Falha ao cadastrar usuário");
                }

            }
            return Result.Ok();

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
