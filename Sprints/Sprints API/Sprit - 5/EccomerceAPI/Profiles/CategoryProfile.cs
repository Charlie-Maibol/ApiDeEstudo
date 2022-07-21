using AutoMapper;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, SearchCategoriesDto>();
            CreateMap<EditCategoryDto, Category>();
        }
        
    }
}
