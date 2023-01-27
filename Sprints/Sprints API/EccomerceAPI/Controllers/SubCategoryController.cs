using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EccomerceAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class SubCategoryController : ControllerBase
    {

        private SubCategoryDao _subCategoryDao;
        private SubCategoryServices _subCategoryServices;


        public SubCategoryController(SubCategoryDao subCategoryDao, SubCategoryServices subCategoryServices)
        {
            _subCategoryDao = subCategoryDao;
            _subCategoryServices = subCategoryServices;
        }

        [HttpPost]
        public IActionResult AddSubCategory([FromBody] CreateSubCategoryDto SubDto)
        {
            SearchSubCategoriesDto sub = _subCategoryServices.AddSubCategory(SubDto);
            return CreatedAtAction(nameof(searchSubId), new { sub.Id }, sub);
        }


        [HttpGet]
        public IActionResult searchSubId(int id)
        {
            SubCategory sub = _context.SubCategories.FirstOrDefault(sub => sub.Id == id);
            if (sub != null)
            {

                SearchSubCategoriesDto subCategory = _mapper.Map<SearchSubCategoriesDto>(sub);
                return Ok(sub);
            }

            return NotFound();
        }

        [HttpGet("Filter")]
        public IActionResult Search([FromQuery] SubCategoryFilterDto subCategoryFilterDto)
        {
            _subCategoryDao.FilterProduct(subCategoryFilterDto);
            return Ok();

        }


        [HttpPut("{ID}")]
        public IActionResult EditSubCategory(int Id, [FromBody] EditSubCategoryDto subCategoryDto)
        {
            _subCategoryServices.EditSubCategory(Id, subCategoryDto);
            return NoContent();

        }

        [HttpDelete("{ID}")]
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
