using AutoMapper;
using Eccomerce.Test;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CategoryServices> logger;

        public CategoryServices( ICategoryDao categoryDao, IProductDao productDao, ISubCategoryDao subCategoryDao,
            IMapper mapper, ILogger<CategoryServices> logger)
        {
            _categoryDao = categoryDao;
            _productDao = productDao;
            _subCategoryDao = subCategoryDao;
            _Mapper = mapper;
            this.logger = logger;
        }


        public Category AddCategory(CreateCategoryDto categoryDto)
        {
            if(categoryDto.Name.Length > 128 || categoryDto.Name.Length <3 
                || categoryDto.Name == string.Empty || categoryDto.Status == false)
            {
                logger.LogWarning($"#### Erro: Nome ou Status não atende aos crítérios.");
                return null;
            }
            var category = _Mapper.Map<Category>(categoryDto);
            logger.LogInformation($"#### Service - Inserção de uma nova categoria. ####");
            return _categoryDao.AddCategory(category);
        }

        public List<SearchCategoriesDto> SearchCategoryId(int Id)
        {
            Category category;
           
            category = _categoryDao.GetId(Id);
            logger.LogInformation($"#### Service - Pesquisa de uma categoria por Id. ####");
            if (category != null)
            {
                logger.LogInformation($"#### Id não encontrado, exibir tudo. ####");
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
                        logger.LogWarning($"#### Erro: Produto não encontrado no banco de dados.");
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
                logger.LogInformation($"#### Service - Editando status uma categoria. ####");
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
                logger.LogInformation($"#### Service - Editando status uma categoria. ####");
                return editCategory;
            }
            logger.LogWarning($"#### Service - Edição falhou pois o ID não existe. ####");
            return null;    
        }
    }
}