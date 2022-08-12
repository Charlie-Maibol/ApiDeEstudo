﻿using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace EccomerceAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class SubCategoryController : ControllerBase
    {

        private CategoryContext _context;
        private IMapper _mapper;

        public SubCategoryController(CategoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddSubCategory(CreateSubCategoryDto dto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == dto.CategoryId);
            if (category.Status == false)
            {
                return BadRequest("Não é possivel cadastrar uma subcategoria em uma categoria inativa");
            }
            SubCategory sub = _mapper.Map<SubCategory>(dto);
            _context.SubCategories.Add(sub);
            _context.SaveChanges();
            return CreatedAtAction(nameof(searchSubId), new {sub.Id }, sub);
        }

        [HttpGet]
        public IEnumerable<SubCategory> ShowSubCategories()
        {
            return _context.SubCategories;
        }

        
        [HttpGet("{Id}")]
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
        public IActionResult Search([FromQuery] string name = null, [FromQuery] int? ord = null,
                    [FromQuery] bool? status = null, [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {
            List<SubCategory> subCategories;
            
            if (name != null && ord == null && status == null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()))
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                
                return Ok(subCategories);
            }
            if (name != null && ord == 1 && status == null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()))
                    .OrderBy(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);

            }
            if (name != null && ord == 2 && status == null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()))
                    .OrderByDescending(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name != null && ord == null && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }

                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower()
                .Contains(name.ToLower()) && fil.Status == status)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name == null && ord == null && status != null)
            {
                subCategories = _context.SubCategories.Where(fil => fil.Status == status)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name == null && ord == 1 && status != null)
            {
                subCategories = _context.SubCategories.Where(fil => fil.Status == status).OrderBy(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name == null && ord == 2 && status != null)
            {
                subCategories = _context.SubCategories.Where(fil => fil.Status == status).OrderByDescending(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name != null && ord == null && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()) && fil.Status == status)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name != null && ord == 1 && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()) && fil.Status == status)
                    .OrderBy(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if (name != null && ord == 2 && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                subCategories = _context.SubCategories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()) && fil.Status == status)
                    .OrderByDescending(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
            }
            if(name == null && ord == null && status == null)
            {
                subCategories = _context.SubCategories.
                    Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List <SearchSubCategoriesDto> subCategoryDto = _mapper.Map<List<SearchSubCategoriesDto>>(subCategories);
                return Ok(subCategories);
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
        [HttpDelete("{ID}")]
        public IActionResult DeletSubCategory(int ID)
        {
            SubCategory subCategory = _context.SubCategories.FirstOrDefault(sub => sub.Id == ID);
            if (subCategory == null)
            {

                return NotFound();
            }
            _context.Remove(subCategory);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
