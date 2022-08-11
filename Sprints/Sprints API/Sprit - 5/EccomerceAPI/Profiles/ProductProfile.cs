using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, SearchProductsDto>();
            CreateMap<EditProductDto, Product>();
        }
    }
}
