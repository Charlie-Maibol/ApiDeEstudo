using AutoMapper;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
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
            Category category = _mapper.Map<Category>(categoryDto);
            _categoryDao.AddCategory(category);
            return CreatedAtAction(nameof(SearchId), new {category.Id }, category);
        }

        [HttpGet("searchid/{Id}")]
        public IActionResult ShowCategories([FromQuery] int? Id = null, [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {
            _categoryDao.ListCategories(pageNumber, itensPerPage, Id);

            return NotFound();

        }

        [HttpGet("Filter")]
        public IActionResult FilterProduct([FromQuery] FiltersCategoryDto categoryFilterDto)
        {

            _categoryDao.FilterCategory(categoryFilterDto);
            return Ok();


        }



        [HttpGet("{ID}")]
        public IActionResult SearchId(int Id)
        {

            Category category = _context.Categories.FirstOrDefault(category => category.Id == Id);
            if (category != null)
            {
                SearchCategoriesDto categoryDto = _mapper.Map<SearchCategoriesDto>(category);
                return Ok(categoryDto);
            }

            return NotFound();
        }

        [HttpPut("{ID}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto Category)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == Id);
            List<SubCategory> subCategory = _context.SubCategories.Where(sub => sub.CategoryId == Id && sub.Status ).ToList();


            if (category == null)
            {

                return NotFound();
            }
            if (Category.Status != true && subCategory.Count > 0 )
            {
                return BadRequest("Ainda existem SubCategorias ativas");
            }

            this.ChangeStatus(Id);
            _mapper.Map(Category, category);
            _context.SaveChanges();
            return NoContent();
        }
        public SearchCategoriesDto ChangeStatus(int Id)
        {

            var cat = _context.Categories.FirstOrDefault(category => category.Id == Id);
            var sub = _context.SubCategories.Where(sub => sub.CategoryId == Id).ToList();
           
            if (sub.Count == 0)
            {
                return null;
            }
            if (cat.Status == false)
            {
                cat.Status = true;
                cat.Modified = DateTime.Now;
            }
            else if (cat.Status == true)
            {
                cat.Status = false;
                cat.Modified = DateTime.Now;
                foreach (SubCategory subcategory in sub)
                {
                    if (subcategory.Status == true)
                    {
                        subcategory.Status = false;
                        subcategory.Modified = DateTime.Now;
                    }
                }
            }

            _context.SaveChanges();
            return null;
        }

        [HttpDelete("{ID}")]
        public IActionResult DeletCategory(int ID)
        {
            _categoryDao.DeleteCategory(ID);
            return NoContent();
        }
    }
}
