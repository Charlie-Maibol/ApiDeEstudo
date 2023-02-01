using AutoMapper;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class CategoryController : ControllerBase
    {
        private CategoryDao _categoryDao;
        private CategoryServices _categoryServices;

        public CategoryController(CategoryDao categoryDao, CategoryServices categoryServices)
        {
            _categoryDao = categoryDao;
            _categoryServices = categoryServices;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDto categoryDto)
        {
            SearchCategoriesDto searchCategoriesDto  = _categoryServices.AddCategory(categoryDto);
            return CreatedAtAction(nameof(SearchCategoryId), new { searchCategoriesDto.Id }, searchCategoriesDto);
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
        [HttpPut("{ID}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto Category)
        {
            

            Result result = _categoryServices.EditCategory(Id, Category);
            if (result.IsFailed)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpPut("{ID}")]
        public IActionResult EditCategoryStatus(int Id)
        {


            var result = _categoryServices.EditCategoryStatus(Id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpDelete("{ID}")]
        public IActionResult DeletCategory(int ID)
        {
            _categoryDao.DeleteCategory(ID);
            return NoContent();
        }
    }
}
