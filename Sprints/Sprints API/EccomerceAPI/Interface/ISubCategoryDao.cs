using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using FluentResults;
using System.Collections.Generic;

namespace Eccomerce.Test
{
    public interface ISubCategoryDao
    {
        void DeleteSubCategory(object subCategory);
        SubCategory GetID(int id);
        List<SubCategory> FilterProduct(SubCategoryFilterDto filterSubCategoryDto);
        SearchSubCategoriesDto AddSubCategory(CreateSubCategoryDto subDto);
        SubCategory SearchSubId(int Id);

        IEnumerable<SubCategory> GetAll();

        Result EditSubCategory(SubCategory subCategory);
    }
}
