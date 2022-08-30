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

        private ProductDao _dao;
        private ProductsServices _service;

        public ProductController(ProductsServices service, ProductDao productDao)
        {
            _service = service;
            _dao = productDao;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            SearchProductsDto searchProducts = _service.AddProduct(productDto);
            return CreatedAtAction(nameof(SearchProdId), new { id = searchProducts.Id }, searchProducts);
        }
        [HttpGet("{ID}")]
        public IActionResult SearchProdId(int? Id)
        {
            List<SearchProductsDto> productDto = _service.SearchProdId(Id);
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


            return Ok(_dao.FilterProduct(name, center, status, weight, height, lengths, widths, price, amountOfProducts, order, pageNumber, itensPerPage));


        }
        [HttpPut("{Id}")]
        public IActionResult EditProduct(int Id, [FromBody] EditProductDto Product)
        {
            Result result = _service.EditProduct(Id, Product);
            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{Id}")]

        public IActionResult DeletProduct(int Id)
        {
            Result result = _service.DeletProduct(Id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
    }

}
