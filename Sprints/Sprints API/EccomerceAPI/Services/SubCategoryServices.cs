using AutoMapper;
using FluentResults;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using Eccomerce.Test;

namespace EccomerceAPI.Services
{
    public class SubCategoryServices
    {

        private ISubCategoryDao _SubCategoryDao;
        private IMapper _Mapper;

        public SubCategoryServices(ISubCategoryDao subCategoryDao, IMapper mapper)
        {
            _SubCategoryDao = subCategoryDao;
            _Mapper = mapper;
        }

        public SubCategory AddSubCategory(CreateSubCategoryDto SubDto)
        {
            var sub = _Mapper.Map<SubCategory>(SubDto);
            var cat =_SubCategoryDao.GetCategoryID(sub);
            if (sub.Name.Length > 128 || sub.Name.Length < 3
                || sub.Name == string.Empty || sub.CategoryId < 1)
            {
                return null;
            }
            if(sub.Status != true || cat.Status != true)
            {
                return null;
            }
            return _SubCategoryDao.AddSubCategory(sub);

        }

        internal Result DeletSubCategory(int id)
        {
            var subCategory = _SubCategoryDao.GetSubId(id);
            if (subCategory == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _SubCategoryDao.DeleteSubCategory(subCategory);
            return Result.Ok();
        }

        public Result EditSubCategory(int Id, EditSubCategoryDto subCategoryDto)
        {
            var subCategory = _SubCategoryDao.GetSubId(Id);
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
            return _SubCategoryDao.GetSubId(Id);
        }
    }
}
