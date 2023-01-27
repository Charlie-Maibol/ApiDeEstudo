using AutoMapper;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Data;
using FluentResults;
using System;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EccomerceAPI.Services
{
    public class SubCategoryServices
    {
      
        private SubCategoryDao _SubCategoryDao;
        private IMapper _Mapper;

        public SubCategoryServices(SubCategoryDao subCategoryDao, IMapper mapper)
        {
            _SubCategoryDao = subCategoryDao;
            _Mapper = mapper;
        }

        public SearchSubCategoriesDto AddSubCategory(CreateSubCategoryDto SubDto)
        {
            SubCategory sub = _Mapper.Map<SubCategory>(SubDto);
            return _SubCategoryDao.AddSubCategory(SubDto);

        }

        internal Result DeletSubCategory(int id)
        {
            var subCategory = _SubCategoryDao.SearchId(id);
            if (subCategory == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _SubCategoryDao.DeleteSubCategory(subCategory);
            return Result.Ok();
        }

        public Result EditSubCategory(int Id, EditSubCategoryDto subCategoryDto)
        {
            var subCategory = _SubCategoryDao.SearchProdId(Id);
            var validationSubCategory = _SubCategoryDao.ValidationSub(Id);
            
            if (validationSubCategory == null)
            {

                return  
            }
            _Mapper.Map(subCategoryDto, subCategory);
            _SubCategoryDao.EditSubCategory(Id, subCategory);
            return Result.Ok();
        }
    }
}
