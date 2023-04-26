using Eccomerce.Test;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EccomerceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryDao _categoryDao;
        private CategoryServices _categoryServices;


        public CategoryController(ICategoryDao categoryDao, CategoryServices categoryServices)
        {
            _categoryDao = categoryDao;
            _categoryServices = categoryServices;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDto categoryDto)
        {
            var category = _categoryServices.AddCategory(categoryDto);
            if (category == null) return BadRequest("Número de caracteres excedida");
            return Ok(category);
        }


        [HttpGet("Filter")]
        public IActionResult FilterProduct([FromQuery] FiltersCategoryDto categoryFilterDto)
        {

            _categoryDao.FilterCategory(categoryFilterDto);
            return Ok();


        }
        [HttpGet("{ID}")]
        public IActionResult SearchCategoryId(int Id)
        {

            List<SearchCategoriesDto> CategoryDto = _categoryServices.SearchCategoryId(Id);
            if (CategoryDto != null)
            {
                return Ok(CategoryDto);

            }
            return NotFound();

        }
        [HttpPut("{Id}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto Category)
        {


            var result = _categoryServices.EditCategory(Id, Category);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("editarStatus/{Id}")]
        public IActionResult EditCategoryStatus(int Id)
        {


            var result = _categoryServices.EditCategoryStatus(Id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletCategory(int Id)
        {
            _categoryDao.DeleteCategory(Id);
            return NoContent();
        }
    }
}
