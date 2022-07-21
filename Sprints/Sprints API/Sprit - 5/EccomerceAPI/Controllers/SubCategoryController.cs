using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos;
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
            SubCategory sub = _mapper.Map<SubCategory>(dto);
            _context.SubCategories.Add(sub);
            _context.SaveChanges();
            return CreatedAtAction(nameof(searchSubId), new { Id = sub.Id }, sub);
        }
        [HttpGet]
        public IActionResult searchSubId(int id)
        {
            SubCategory sub = _context.SubCategories.FirstOrDefault(sub => sub.Id == id);
            if (sub != null)
            {

                SearchCategoriesDto subCategoryDto = _mapper.Map<SearchCategoriesDto>(sub);
                return Ok(subCategoryDto);
            }

            return NotFound();
        }
    }
}
