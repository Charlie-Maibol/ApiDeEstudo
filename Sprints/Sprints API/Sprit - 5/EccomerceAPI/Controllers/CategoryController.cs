
using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            return CreatedAtAction(nameof(SearchId), new { Id = category.ID }, category);
        }

        [HttpGet]
        public IEnumerable<Category> ShowCategories()
        {
            return _context.Categories;
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

            Category category = _context.Categories.FirstOrDefault(category => category.ID == Id);
            if (category != null)
            {
                SearchCategoriesDto categoryDto = _mapper.Map<SearchCategoriesDto>(category);
                return Ok(categoryDto);
            }

            return NotFound();
        }

        [HttpGet("searchstatus/{status}")]
        public IActionResult SearchStatus(bool status)
        {

            if (status == true)
            {
                List<Category> category = _context.Categories.Where(statusCategory => statusCategory.Status == true).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(category);
                return Ok(category);
            }
            else if (status == false)
            {
                List<Category> category = _context.Categories.Where(statusCategory => statusCategory.Status == false).ToList();
                List<SearchCategoriesDto> categoryDto = _mapper.Map<List<SearchCategoriesDto>>(category);
                return Ok(category);
            }

            return NotFound();
        }


        [HttpPut("{ID}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto Category)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.ID == Id);
            if (category == null)
            {

                return NotFound();
            }
            _mapper.Map(Category, category);
            _context.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{ID}")]
        public IActionResult DeletCategory(int ID)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.ID == ID);
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
