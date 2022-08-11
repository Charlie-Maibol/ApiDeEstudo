
using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EccomerceAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class CategoryController : ControllerBase
    {
        private CategoryContext _context;
        private IMapper _mapper;

        public CategoryController(CategoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchId), new { Id = category.Id }, category);
        }

        [HttpGet("searchId/{Id}")]
        public IActionResult ShowCategories([FromQuery] int? Id = null, [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {
            List<Category> categories;

            if (Id == null)
            {
                categories = _context.Categories.ToList();
            }

            else
            {
                categories = _context.Categories.Where(cat => cat.Id == Id)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> category = _mapper.Map<List<SearchCategoriesDto>>(categories);

            }
            if (categories != null)
            {
                List<SearchCategoriesDto> category = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }

            return NotFound();

        }

        [HttpGet("Filter")]
        public IActionResult Search([FromQuery] string name = null, [FromQuery] int? ord = null,
            [FromQuery] bool? status = null, [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {
              
             List<Category> categories;
            if (name != null && ord == null && status == null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()))
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name != null && ord == 1 && status == null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()))
                    .OrderBy(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);

            }
            if (name != null && ord == 2 && status == null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()))
                    .OrderByDescending(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if(name != null && ord == null && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower()
                .Contains(name.ToLower()) && fil.Status == status)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List <SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name == null && ord == null && status != null)
            {
                categories = _context.Categories.Where(fil => fil.Status == status)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name == null && ord == 1 && status != null)
            {
                categories = _context.Categories.Where(fil => fil.Status == status).OrderBy(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name == null && ord == 2 && status != null)
            {
                categories = _context.Categories.Where(fil => fil.Status == status).OrderByDescending(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name != null && ord == null && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()) && fil.Status == status)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name != null && ord == 1 && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()) && fil.Status == status)
                    .OrderBy(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name != null && ord == 2 && status != null)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
                {
                    return BadRequest();
                }
                categories = _context.Categories.Where(fil => fil.Name.ToLower().Contains(name.ToLower()) && fil.Status == status)
                    .OrderByDescending(fil => fil.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }
            if (name == null && ord == null && status == null)
            {
                categories = _context.Categories.ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Ok(categories);
            }



            return NotFound();
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 128)
            {
                return BadRequest();
            }

            var category = _context.Categories.Where(categories => categories.Name.ToLower().Contains(name.ToLower())).ToList();
            if (category.Count != 0)
            {
                List<Category> categoryDto = _mapper.Map<List<Category>>(category);
                return Ok(category);
            }



            return NotFound();
        }

        [HttpGet("{ID}")]
        public IActionResult SearchId(int Id)
        {

            Category category = _context.Categories.FirstOrDefault(category => category.Id == Id);
            if (category != null)
            {
                SearchCategoriesDto categoryDto = _mapper.Map<SearchCategoriesDto>(category);
                return Ok(category);
            }

            return NotFound();
        }

        [HttpGet("status/{status}")]
        public IActionResult SearchStatus(bool status)
        {

            List<Category> category = _context.Categories.OrderByDescending(statusCategory => statusCategory.Status == status).ToList();
            List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(category);
            return Ok(category);


        }


        [HttpPut("{Id}")]
        public IActionResult ChangeStatus(int Id)
        {

            var cat = _context.Categories.FirstOrDefault(category => category.Id == Id);
            var sub = _context.SubCategories.Where(sub => sub.CategoryId == Id).ToList();
            if (sub.Count == 0)
            {
                return NotFound();
            }
            if (cat.Status == false)
            {
                cat.Status = true;
                cat.Modified = DateTime.Now;
            }
            else
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
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public IActionResult DeletCategory(int ID)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == ID);
            if (category == null)
            {

                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
