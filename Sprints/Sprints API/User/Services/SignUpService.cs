using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                if (ConfirmBirthDay(identityUser.BirthDay) == false
                    || ConfirmCPF(identityUser.CPF) == false)
                    return Result.Fail("Falha ao cadastrar usuário");
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

        //public async Task<List<SearchUserDto>> GetUserId(int? id)
        //{
        //    var users = await _userManager.Users.ToListAsync();
        //    List<SearchUserDto> searchUserDto = new();
        //    foreach (var user in users)
        //    {
        //        var userDto = _mapper.Map<SearchUserDto>(user);
        //        searchUserDto.Add(userDto);
        //    }
        //    if (id != null)
        //    {
        //        return searchUserDto.Where(user => user.Id == id).ToList();
        //    }
        //    throw new HttpResponseException(HttpStatusCode.BadRequest);
        //}

        public async Task<List<SearchUserDto>> GetUser(string userName, string cpf, bool? status, string email)
        {
            var users = await _userManager.Users.ToListAsync();
            List<SearchUserDto> searchUserDto = new();
            foreach(var user in users)
            {
                var userDto = _mapper.Map<SearchUserDto>(user);
                searchUserDto.Add(userDto);
            }
            if(userName != null)
            {
                return searchUserDto.Where(user => user.UserName.ToLower().Contains(userName.ToLower())).ToList();
            }
            if (email != null)
            {
                return searchUserDto.Where(user => user.Email == email).ToList();
            }
            if (status != null)
            {
                return searchUserDto.Where(user => user.Status == status).ToList();
            }
            if (cpf != null)
            {
                return searchUserDto.Where(user => user.CPF == cpf).ToList();
            }
            return searchUserDto;
        }

        public async Task<Result> EditUser(int id, EditUserDto editUser)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            var address = await GetAdress(user.ZipCode);
            if (user.ZipCode != null)
            {
                user.UF = address.UF;
                user.Neighborhood = address.Neighborhood;
                user.City = address.City;
                user.Street = address.Street;
                user.ZipCode = address.ZipCode;
                user.AddComplemente = address.AddComplemente;
            }
            if (user.CPF != null)
            {
                user.CPF = editUser.CPF;
            }
            if (user.UserName != null)
            {
                user.UserName = editUser.UserName;
            }
            if (user.Email != null)
            {
                user.Email = editUser.Email;
            }
            if (user.BirthDay != null)
            {
                user.BirthDay = editUser.BirthDay;
            }
            await _userManager.UpdateAsync(user);
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
        private static bool ConfirmBirthDay(DateTime? identityUser)
        {
            if (identityUser > DateTime.Today) return false;
            return true;
        }

        private static bool ConfirmCPF(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digit;
            int plus;
            int remain;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            Console.WriteLine("Tamanho: " + cpf.Length);
            if (cpf.Length != 11) { return false; }

            tempCpf = cpf.Substring(0, 9);
            plus = 0;

            for (int i = 0; i < 9; i++)
            {
                plus += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            remain = plus % 11;

            if (remain < 2) { remain = 0; }
            else { remain = 11 - remain; }

            digit = remain.ToString();

            tempCpf += digit;

            plus = 0;

            for (int i = 0; i < 10; i++)
            {
                plus += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            remain = plus % 11;

            if (remain < 2) { remain = 0; }
            else { remain = 11 - remain; }

            digit += remain.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
