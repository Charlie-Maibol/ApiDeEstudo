using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace EccomerceAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductDao _productDao;
        private ProductsServices _productService;

        public ProductController(ProductsServices service, IProductDao productDao)
        {
            _productService = service;
            _productDao = productDao;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            SearchProductsDto searchProducts = _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(SearchProdId), new { id = productDto.Id }, productDto);
        }
        [HttpGet("{Id}")]
        public IActionResult SearchProdId(int? Id)
        {
            List<SearchProductsDto> productDto = _productService.SearchProdId(Id);
            if (productDto != null)
            {
                return Ok(productDto);

            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult FilterProduct([FromQuery]ProductFilterDto productFilterDto)
        {

            _productDao.FilterProduct(productFilterDto);
            return Ok();


        }
        [HttpPut("{Id}")]
        public IActionResult EditProduct(int Id, [FromBody] EditProductDto Product)
        {
            Result result = _productService.EditProduct(Id, Product);
            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{Id}")]

        public IActionResult DeletProduct(int Id)
        {
            Result result = _productService.DeletProduct(Id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
    }

}
