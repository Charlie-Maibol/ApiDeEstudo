using Eccomerce.Test;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;

namespace EccomerceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {

        private ISubCategoryDao _subCategoryDao;
        private SubCategoryServices _subCategoryServices;
        private readonly ILogger<SubCategoryController> logger;

        public SubCategoryController(ISubCategoryDao subCategoryDao, SubCategoryServices subCategoryServices,
            ILogger<SubCategoryController> logger)
        {
            _subCategoryDao = subCategoryDao;
            _subCategoryServices = subCategoryServices;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult AddSubCategory([FromBody] CreateSubCategoryDto SubDto)
        {
            SubCategory sub;
            logger.LogInformation($"#### POST - Inserção de uma nova subcategoria. ####");
            using (Operation.Time("#### Tempo de adição de uma nova Subcategoria."))
            {
                sub = _subCategoryServices.AddSubCategory(SubDto);
                if (sub == null)
                {
                    logger.LogWarning("Erro ao criar uma sub categoria");
                    return BadRequest("Nem todos os requisitos foram cumprindos");
                } 
            }
            return Ok(sub);
        }


        [HttpGet]
        public IActionResult searchSubId(int Id)
        {
            using (Operation.Time("#### Tempo de Busca de uma Subcategoria por ID."))
            {
                var sub = _subCategoryServices.GetId(Id);
                if (sub != null)
                {
                    logger.LogInformation($"#### GET - Busca de uma subcategoria. ####");
                    return Ok(sub);
                }
            }
            logger.LogWarning("Erro ao buscar a sub categoria");
            return NotFound();  
        }

        [HttpGet("Filter")]
        public IActionResult Search([FromQuery] SubCategoryFilterDto subCategoryFilterDto)
        {
            using (Operation.Time("#### Tempo de Busca de uma Subcategoria por ID."))
            {
                _subCategoryDao.FilterProduct(subCategoryFilterDto);
                logger.LogInformation($"#### GET - Busca de uma subcategoria. ####");
                return Ok();
            }
        }


        [HttpPut("{Id}")]
        public IActionResult EditSubCategory(int Id, [FromBody] EditSubCategoryDto subCategoryDto)
        {
            using (Operation.Time("#### Tempo de Busca de uma Subcategoria por ID."))
            {
                _subCategoryServices.EditSubCategory(Id, subCategoryDto);
                logger.LogInformation($"#### PUT - Busca de uma subcategoria. ####");
                return NoContent();
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult DeletSubCategory(int Id)
        {
            using (Operation.Time("#### Tempo de Busca de uma Subcategoria por ID."))
            {
                Result result = _subCategoryServices.DeletSubCategory(Id);
                if (result.IsFailed)
                {
                    return NotFound();
                }
            }
            logger.LogInformation($"#### DELETE - Exclusão de uma subcategoria. ####");
            return Ok();
        }
    }
}
