using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using FluentResults;
using System.Collections.Generic;

namespace Eccomerce.Test
{
    public interface ISubCategoryDao
    {
        void DeleteSubCategory(object subCategory);
        List<SubCategory> FilterProduct(SubCategoryFilterDto filterSubCategoryDto);
        SubCategory AddSubCategory(SubCategory sub);
        SubCategory GetSubId(int Id);
        Category GetCategoryID(SubCategory cat);

        IEnumerable<SubCategory> GetAll();

        Result EditSubCategory(SubCategory subCategory);
    }
}
