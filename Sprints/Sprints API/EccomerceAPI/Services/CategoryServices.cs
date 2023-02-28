using AutoMapper;
using Eccomerce.Test;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceAPI.Services
{
    public class CategoryServices
    {
        
        private ICategoryDao _categoryDao;
        private IProductDao _productDao;
        private ISubCategoryDao _subCategoryDao;
        private IMapper _Mapper;

        public CategoryServices( ICategoryDao categoryDao, IProductDao productDao, ISubCategoryDao subCategoryDao, IMapper mapper)
        {
            _categoryDao = categoryDao;
            _productDao = productDao;
            _subCategoryDao = subCategoryDao;
            _Mapper = mapper;
        }


        public Category AddCategory(CreateCategoryDto categoryDto)
        {
            if(categoryDto.Name.Length > 128 || categoryDto.Name.Length <3 
                || categoryDto.Name == string.Empty || categoryDto.Status == false)
            {
                return null;
            }
            var category = _Mapper.Map<Category>(categoryDto);
            return _categoryDao.AddCategory(category);
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