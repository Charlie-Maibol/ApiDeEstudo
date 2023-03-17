using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Category>();
            CreateMap<Category, SearchProductsDto>();
            CreateMap<EditProductDto, Category>();
           
        }
    }
}
