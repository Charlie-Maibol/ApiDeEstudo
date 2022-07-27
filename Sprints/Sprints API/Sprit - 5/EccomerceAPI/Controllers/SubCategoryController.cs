﻿using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EccomerceAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class SubCategoryController : ControllerBase
    {
        
        private CategoryContext _context;
        private  IMapper _mapper;

        public SubCategoryController(CategoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddSubCategory(CreateSubCategoryDto dto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.ID == dto.CategoryId);
            if (category.Status == false)
            {
                return BadRequest();
            }
            SubCategory sub = _mapper.Map<SubCategory>(dto);
            _context.SubCategories.Add(sub);
            _context.SaveChanges();
            return CreatedAtAction(nameof(searchSubId), new { Id = sub.Id }, sub);
        }
        [HttpGet("{id}")]
        public IActionResult searchSubId(int id)
        {
            SubCategory sub = _context.SubCategories.FirstOrDefault(sub => sub.Id == id);
            if (sub != null)
            {

                SearchSubCategoriesDto subCategory = _mapper.Map<SearchSubCategoriesDto>(sub);
                return Ok(subCategory);
            }

            return NotFound();
        }
        [HttpPut("{ID}")]
        public IActionResult EditSubCategory(int Id, [FromBody] EditSubCategoryDto SubCategory)
        {
            SubCategory subCategory = _context.SubCategories.FirstOrDefault(subCategory => subCategory.Id == Id);
            if (subCategory == null)
            {

                return NotFound();
            }
            _mapper.Map(SubCategory, subCategory);
            _context.SaveChanges();
            return NoContent();


        }
    }
}
