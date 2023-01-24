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
        public IActionResult SearchCategoryId(int? Id)
        {

            List<SearchCategoriesDto> productDto = _categoryServices.SearchCategoryId(Id);
            if (productDto != null)
            {
                return Ok(productDto);

            }
            return NotFound();

        }
        [HttpPut("{ID}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto Category)
        {
            

            Result result = _categoryServices.EditProduct(Id, Category);
            if (result.IsFailed)
            {
                return NotFound();
            }
            
            return NoContent();
        }


        [HttpDelete("{ID}")]
        public IActionResult DeletCategory(int ID)
        {
            _categoryDao.DeleteCategory(ID);
            return NoContent();
        }
    }
}
