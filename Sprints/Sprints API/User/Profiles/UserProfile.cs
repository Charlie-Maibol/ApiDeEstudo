using UserAPI.Data.DTOs;
using AutoMapper;
using UserAPI.Models;

namespace UserAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, Users>();
        }
    }
}
