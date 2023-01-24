using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
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

        public SearchCategoriesDto AddCategory(CreateCategoryDto categoryDto)
        {
             return _CategoryDao.AddCategory(categoryDto);
        }

        public List<SearchCategoriesDto> SearchCategoryId(int? Id)
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

        internal Result EditProduct(int? Id, EditCategoryDto categoryDto)
        {
            var category = _CategoryDao.SearchId(Id);
            if(Id != null)
            {
                _CategoryDao.EditValidation(Id);
            }
            _Mapper.Map(categoryDto, category);
            _CategoryDao.EditCategory(Id, category);
            _CategoryDao.ChangeStatus(Id);
            return null;
        }
        
    }
}
