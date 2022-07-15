
using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos;
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
                return NotFound();
           }

           var category = _context.Categories.Where(categories => categories.Name.ToLower().Contains(name.ToLower())).ToList();
           if (category != null)
           {
               List<Category> CategoryDto = _mapper.Map<List<Category>>(category);
                return Ok(category);
           }



            return NotFound();
        }

        [HttpGet("{ID}")]
        public IActionResult SearchId(int Id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.ID == Id);
            if (category != null )
            {
                SearchCategoriesDto SearchDto = _mapper.Map<SearchCategoriesDto>(category);
                return Ok(SearchDto);
            }
            
            return NotFound();
        }

       
        [HttpPut("{ID}")]
        public IActionResult EditCategory(int Id, [FromBody] EditCategoryDto categoryDto)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.ID   == Id);
            if (category == null)
            {

                return NotFound();
            }
            _mapper.Map(categoryDto, category);
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
