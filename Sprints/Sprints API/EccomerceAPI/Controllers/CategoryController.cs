using Eccomerce.Test;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SerilogTimings;
using System.Collections.Generic;

namespace EccomerceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryDao _categoryDao;
        private CategoryServices _categoryServices;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryDao categoryDao, CategoryServices categoryServices, ILogger<CategoryController> logger)
        {
            _categoryDao = categoryDao;
            _categoryServices = categoryServices;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDto categoryDto)
        {
            logger.LogInformation($"#### POST - Cadastro de uma nova categoria. ####");

            Category category;
            using (Operation.Time("Tempo de casdastro de nova categoria"))
            {
                logger.LogInformation($"#### Requisição -> {JsonConvert.SerializeObject(categoryDto)}. ####");
                category = _categoryServices.AddCategory(categoryDto);
            }

            if (category == null)
            {
                logger.LogWarning($"#### Erro: Categoria informada não existe.");
                return BadRequest("Número de caracteres excedida");
            }

            return Ok(category);
        }


        [HttpGet("Filter")]
        public IActionResult FilterProduct([FromQuery] FiltersCategoryDto categoryFilterDto)
        {

            logger.LogInformation($"#### GET - Requisição de busca personalizada. ####");
            using (Operation.Time("Tempo de casdastro de nova categoria"))
            {
                _categoryDao.FilterCategory(categoryFilterDto);

            }
            return Ok();


        }
        [HttpGet("{ID}")]
        public IActionResult SearchCategoryId(int Id)
        {
            logger.LogInformation($"#### GET - Requisição de por ID. ####");
            using (Operation.Time("Tempo de pesquisa de ID de uma categoria"))
            {
                List<SearchCategoriesDto> CategoryDto = _categoryServices.SearchCategoryId(Id);
                if (CategoryDto != null)
                {
                    return Ok(CategoryDto);

                }

            }
            logger.LogWarning($"#### Erro: Categoria não encontrada no banco de dados.");
            return NotFound();

        }
        [HttpPut("{Id}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto Category)
        {

            logger.LogInformation($"#### PUT - Requisição de editar categoria. ####");
            using (Operation.Time("Tempo de Edição de uma categoria"))
            {
                var result = _categoryServices.EditCategory(Id, Category);
                if (result == null)
                {
                    logger.LogWarning($"#### Erro: Categoria não pode ser editada.");
                    return NotFound();
                }
            }
            return NoContent();
        }

        [HttpPut("editarStatus/{Id}")]
        public IActionResult EditCategoryStatus(int Id)
        {

            logger.LogInformation($"#### PUT - Requisição de editar status da categoria. ####");
            using (Operation.Time("Tempo de Edição de uma categoria"))
            {
                var result = _categoryServices.EditCategoryStatus(Id);
            if (result != null)
            {

                return Ok(result);
            }

            }
            logger.LogWarning($"#### Erro: Categoria informada não existe no banco de dados.");
            return NotFound();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletCategory(int Id)
        {
            logger.LogInformation($"#### DELETE - Requisição de deletar uma categoria. ####");
            using (Operation.Time("Tempo de exclusão de uma categoria"))
            {
                _categoryDao.DeleteCategory(Id);
            }             
            return NoContent();
        }
    }
}
