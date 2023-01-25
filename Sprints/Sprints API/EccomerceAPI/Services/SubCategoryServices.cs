using AutoMapper;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Data;
using FluentResults;
using System;
using EccomerceAPI.Data.Dao;

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
    }
}
