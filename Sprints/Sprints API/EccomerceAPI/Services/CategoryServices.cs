using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using System;
using System.Collections.Generic;

namespace EccomerceAPI.Services
{
    public class CategoryServices
    {
        private AppDbContext _Context;
        private CategoryDao _CategoryDao;
        private IMapper _Mapper;

        public CategoryServices(AppDbContext context, CategoryDao categotyDao, IMapper mapper)
        {
            _Context = context;
            _CategoryDao = categotyDao;
            _Mapper = mapper;
        }

        internal List<SearchCategoriesDto> SearchCategoryId(int Id)
        {
            List<Category> category;

            category = _CategoryDao.NullCategories(Id);
            if (category != null)
            {
                List<SearchCategoriesDto> categoryDto = _Mapper.Map<List<SearchCategoriesDto>>(category);
                return categoryDto;
            }
            return null;
        }

        internal List<SearchCategoriesDto> SearchProdId(object id)
        {
            throw new NotImplementedException();
        }
    }
}
