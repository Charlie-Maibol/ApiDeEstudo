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
            CreateMap<SearchUserDto, CustomIdentityUser>();
            CreateMap<CustomIdentityUser, SearchUserDto>();
            CreateMap<Users, SearchUserDto>();
            CreateMap<EditUserDto, CustomIdentityUser>();
            CreateMap<EditUserDto, Users>();    
           
        }
    }
}
