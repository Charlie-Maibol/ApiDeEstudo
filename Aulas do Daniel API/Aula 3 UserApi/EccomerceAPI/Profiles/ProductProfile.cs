using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, SearchProductsDto>();
            CreateMap<EditProductDto, Product>();
           
        }
    }
}
