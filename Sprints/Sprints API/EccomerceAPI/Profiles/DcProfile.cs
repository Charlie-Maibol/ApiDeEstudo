using AutoMapper;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class DcProfile : Profile
    {
                
            public DcProfile()
            {
                CreateMap<CreateDcDto, Dc>();
                CreateMap<Dc, SearchDcsDto>();
                CreateMap<EditDcDto, Dc>();

            }
        
    }
}
