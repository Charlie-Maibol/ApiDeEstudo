using UserAPI.Data.DTOs;
using AutoMapper;
using UserAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace UserAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, Users>();
            CreateMap<Users, IdentityUser<int>>();
            CreateMap<Users, CustomIdentityUser>();
            CreateMap<CustomIdentityUser, EditUserDto>();
            CreateMap<SearchUserDto, CustomIdentityUser>();
           
        }
    }
}
