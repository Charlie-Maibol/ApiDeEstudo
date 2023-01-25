using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


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

        //[HttpPost]
        //public IActionResult AddSubCategory(CreateSubCategoryDto SubDto)
        //{
            
        //    SubCategory sub = _mapper.Map<SubCategory>(SubDto);
        //    _context.SubCategories.Add(sub);
        //    _context.SaveChanges();
        //    return CreatedAtAction(nameof(searchSubId), new {sub.Id }, sub);
        //}

        //[HttpGet]
        //public IEnumerable<SubCategory> ShowSubCategories()
        //{
        //    return _context.SubCategories;
        //}

        
        //[HttpGet("{Id}")]
        //public IActionResult searchSubId(int id)
        //{
        //    SubCategory sub = _context.SubCategories.FirstOrDefault(sub => sub.Id == id);
        //    if (sub != null)
        //    {

        //        SearchSubCategoriesDto subCategory = _mapper.Map<SearchSubCategoriesDto>(sub);
        //        return Ok(sub);
        //    }

        //    return NotFound();
        //}

        [HttpGet("Filter")]
        public IActionResult Search([FromQuery] SubCategoryFilterDto subCategoryFilterDto)
        {
            _subCategoryDao.FilterProduct(subCategoryFilterDto);
            return Ok();



        }


        [HttpPut("{ID}")]
        //public IActionResult EditSubCategory(int Id, [FromBody] EditSubCategoryDto subCategoryDto)
        //{
        //    SubCategory subCategory = _context.SubCategories.FirstOrDefault(sub => sub.Id == Id);
        //    List<Product> product = _context.Products.Where(prod => prod.subCategoryId == Id && prod.Status).ToList();
        //    if (subCategory == null)
        //    {

        //        return NotFound();
        //    }
        //    if (product.Count > 0 && subCategory.Status != true)
        //    {
        //        return BadRequest("Ainda existem produtos ativos");
        //    }
        //    _mapper.Map(subCategoryDto, subCategory);
        //    _context.SaveChanges();
        //    return NoContent();

        //}

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
