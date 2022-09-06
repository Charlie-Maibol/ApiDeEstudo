using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace EccomerceAPI.Controllers
{

    [ApiController]
    [Route("{controller}")]
    public class ProductController : ControllerBase
    {

        private ProductDao _productDao;
        private ProductsServices _productService;

        public ProductController(ProductsServices service, ProductDao productDao)
        {
            _productService = service;
            _productDao = productDao;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            SearchProductsDto searchProducts = _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(SearchProdId), new { id = searchProducts.Id }, searchProducts);
        }
        [HttpGet("{ID}")]
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
        public IActionResult FilterProduct([FromQuery] string name, [FromQuery] string center, [FromQuery] bool? status, [FromQuery] double? weight,
            [FromQuery] double? height, [FromQuery] double? lengths, [FromQuery] double? widths,
            [FromQuery] double? price, [FromQuery] int? amountOfProducts, [FromQuery] int? order,
            [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {


            return Ok(_productDao.FilterProduct(name, center, status, weight, height, lengths, widths, price, amountOfProducts, order, pageNumber, itensPerPage));


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
