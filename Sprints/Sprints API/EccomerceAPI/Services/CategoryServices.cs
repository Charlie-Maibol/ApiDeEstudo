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
using System.Linq;

namespace EccomerceAPI.Services
{
    public class CategoryServices
    {
        private AppDbContext _context;
        private CategoryDao _categoryDao;
        private ProductDao _productDao;
        private SubCategoryDao _subCategoryDao;
        private IMapper _Mapper;

        public CategoryServices(AppDbContext context, CategoryDao categoryDao, ProductDao productDao, SubCategoryDao subCategoryDao, IMapper mapper)
        {
            _context = context;
            _categoryDao = categoryDao;
            _productDao = productDao;
            _subCategoryDao = subCategoryDao;
            _Mapper = mapper;
        }

        public SearchCategoriesDto AddCategory(CreateCategoryDto categoryDto)
        {
            return _categoryDao.AddCategory(categoryDto);
        }

        public List<SearchCategoriesDto> SearchCategoryId(int Id)
        {
            Category category;

            category = _categoryDao.GetId(Id);
            if (category != null)
            {
                List<SearchCategoriesDto> categoryDto = _Mapper.Map<List<SearchCategoriesDto>>(category);
                return categoryDto;
            }
            return null;
        }

        public SearchCategoriesDto EditCategoryStatus(int Id)
        {
            var editCategory = _categoryDao.GetId(Id);
            var getProducts = _productDao.GetAll().Where(p => p.subCategoryId == editCategory.Id).ToList();
            var getSubCategories = _subCategoryDao.GetAll().Where(sub => sub.CategoryId == Id).ToList();

            if (editCategory != null)
            {
                if (editCategory.Status == true)
                {
                    if (getProducts.Count != 0)
                    {
                        return null;
                    }
                    else
                    {
                        editCategory.Status = false;
                        editCategory.Modified = DateTime.Now;


                        foreach (SubCategory sub in getSubCategories)
                        {
                            sub.Status = false;
                        }
                    }
                }
                else
                {
                    editCategory.Status = true;
                    editCategory.Modified = DateTime.Now;

                    foreach (SubCategory sub in getSubCategories)
                    {
                        sub.Status = false;
                    }

                }
                _categoryDao.EditCategory(editCategory);
            }
            return null;
        }

        public Category EditCategory(int Id, EditCategoryDto category)
        {
            var editCategory = _categoryDao.GetId(Id);
            if(editCategory != null)
            {
                _Mapper.Map(category, editCategory);
                _categoryDao.EditCategory(editCategory);
                return editCategory;
            }
            return null;    
        }
    }
}