using AutoMapper;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<CreateSubCategoryDto, SubCategory>();
            CreateMap<SubCategory, SearchSubCategoriesDto>();
            CreateMap<EditSubCategoryDto, SubCategory>();
        }
    }
}
