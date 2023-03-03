using Eccomerce.Test;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EccomerceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {

        private ISubCategoryDao _subCategoryDao;
        private SubCategoryServices _subCategoryServices;


        public SubCategoryController(ISubCategoryDao subCategoryDao, SubCategoryServices subCategoryServices)
        {
            _subCategoryDao = subCategoryDao;
            _subCategoryServices = subCategoryServices;
        }

        [HttpPost]
        public IActionResult AddSubCategory([FromBody] CreateSubCategoryDto SubDto)
        {
            var sub = _subCategoryServices.AddSubCategory(SubDto);
            if(sub == null) 
            {
                return BadRequest("Nem todos os requisitos foram cumprindos");
            }
            return Ok(sub);
        }


        [HttpGet]
        public IActionResult searchSubId(int Id)
        {
            var sub = _subCategoryServices.GetId(Id);
            if(sub != null) { return Ok(sub); } 
            return NotFound();  
        }

        [HttpGet("Filter")]
        public IActionResult Search([FromQuery] SubCategoryFilterDto subCategoryFilterDto)
        {
            _subCategoryDao.FilterProduct(subCategoryFilterDto);
            return Ok();

        }


        [HttpPut("{Id}")]
        public IActionResult EditSubCategory(int Id, [FromBody] EditSubCategoryDto subCategoryDto)
        {
            _subCategoryServices.EditSubCategory(Id, subCategoryDto);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        public IActionResult DeletSubCategory(int Id)
        {
            Result result = _subCategoryServices.DeletSubCategory(Id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
