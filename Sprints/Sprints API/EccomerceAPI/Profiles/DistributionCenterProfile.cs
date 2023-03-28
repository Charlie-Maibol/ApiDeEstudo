using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class DistributionCenterProfile : AutoMapper.Profile
    {
                
            public DistributionCenterProfile()
            {
                CreateMap<CreateDistributionCenterDto, DistributionCenter>();
                CreateMap<DistributionCenter, SearchDistributionCentersDto>();
                CreateMap<EditDistributionCenterDto, DistributionCenter>();

            }
        
    }
}
