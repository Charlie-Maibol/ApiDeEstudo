﻿using AutoMapper;

using FluentResults;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using System;

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
            var subCategory = _SubCategoryDao.GetID(id);
            if (subCategory == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _SubCategoryDao.DeleteSubCategory(subCategory);
            return Result.Ok();
        }

        public Result EditSubCategory(int Id, EditSubCategoryDto subCategoryDto)
        {
            var subCategory = _SubCategoryDao.SearchSubId(Id);
            if (subCategory != null)
            {

                _Mapper.Map(subCategoryDto, subCategory);
                _SubCategoryDao.EditSubCategory(subCategory);
                return Result.Ok();
            }
            return Result.Fail("SubCategoria não encontrada");
        }

        internal object GetId(int Id)
        {
            return _SubCategoryDao.SearchSubId(Id);
        }
    }
}
