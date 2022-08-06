using AutoMapper;
using EccomerceAPI.Controllers;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using System.Linq;

namespace EccomerceAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, SearchCategoriesDto>().ForMember(category => category.SubCategories, opts => opts
                .MapFrom(category => category.SubCategories.Select(c => new { c.Id, c.Name, c.Status, c.Created, c.Modified, c.CategoryId })));
            CreateMap<EditCategoryDto, Category>();
        }
        
    }
}
