using AutoMapper;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class DistribuitonCenterProfile : AutoMapper.Profile
    {
                
            public DistribuitonCenterProfile()
            {
                CreateMap<CreateDistribuitonCenterDto, DistribuitonCenter>();
                CreateMap<DistribuitonCenter, SearchDistribuitonCentersDto>();
                CreateMap<EditDistribuitonCenterDto, DistribuitonCenter>();

            }
        
    }
}
