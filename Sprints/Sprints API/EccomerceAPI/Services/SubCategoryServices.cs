using AutoMapper;
using FluentResults;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using Eccomerce.Test;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace EccomerceAPI.Services
{
    public class SubCategoryServices
    {

        private ISubCategoryDao _SubCategoryDao;
        private IMapper _Mapper;
        private ILogger<SubCategoryServices> logger;

        public SubCategoryServices(ISubCategoryDao subCategoryDao, IMapper mapper, ILogger<SubCategoryServices> logger)
        {
            _SubCategoryDao = subCategoryDao;
            _Mapper = mapper;
            this.logger = logger;
        }

        public SubCategory AddSubCategory(CreateSubCategoryDto SubDto)
        {
            var sub = _Mapper.Map<SubCategory>(SubDto);
            var cat =_SubCategoryDao.GetCategoryID(sub);
            if (sub.Name.Length > 128 || sub.Name.Length < 3
                || sub.Name == string.Empty || sub.CategoryId < 1)
            {
                logger.LogWarning($"#### Erro: Nome ou Status não atende aos crítérios.");
                return null;
            }
            if(sub.Status != true || cat.Status != true)
            {
                logger.LogWarning($"#### Erro: Status não atende aos crítérios.");
                return null;
            }
            logger.LogInformation($"#### Service - Inserção de uma nova subcategoria. ####");
            return _SubCategoryDao.AddSubCategory(sub);

        }

        internal Result DeletSubCategory(int id)
        {
            var subCategory = _SubCategoryDao.GetSubId(id);
            if (subCategory == null)
            {
                logger.LogWarning($"#### Erro: SubCategoria não existe no banco de dados");
                return Result.Fail("SubCategoria não encontrada");
            }
            logger.LogInformation($"#### Service - Exclusão de uma subcategoria. ####");
            _SubCategoryDao.DeleteSubCategory(subCategory);
            return Result.Ok();
        }

        public Result EditSubCategory(int Id, EditSubCategoryDto subCategoryDto)
        {
            var subCategory = _SubCategoryDao.GetSubId(Id);
            if (subCategory != null)
            {
                logger.LogInformation($"#### Service - Edição de uma subcategoria. ####");
                _Mapper.Map(subCategoryDto, subCategory);
                _SubCategoryDao.EditSubCategory(subCategory);
                return Result.Ok();
            }
            logger.LogWarning($"#### Erro: SubCategoria não existe no banco de dados");
            return Result.Fail("SubCategoria não encontrada");
        }

        internal object GetId(int Id)
        {
            logger.LogInformation($"#### Service - Pesquisa de uma subcategoria. ####");
            return _SubCategoryDao.GetSubId(Id);
        }
    }
}
