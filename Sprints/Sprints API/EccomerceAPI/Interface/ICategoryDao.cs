
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using FluentResults;
using System.Collections.Generic;

namespace Eccomerce.Test
{
    public interface ICategoryDao
    {
        Category AddCategory(Category category);
        void DeleteCategory(int iD);
        Category GetId(int Id);
        Result ListCategories(int pageNumber, int itensPerPage, int? Id);

        List<Category> FilterCategory(FiltersCategoryDto filterCategoryDto);

        Result EditCategory(Category editCategory);
        SearchCategoriesDto ChangeStatus(int? Id);
    }
}
