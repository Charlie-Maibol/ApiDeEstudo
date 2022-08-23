using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace EccomerceAPI.Controllers
{

    [ApiController]
    [Route("{controller}")]
    public class ProductController : ControllerBase
    {


        private ProductsServices _service;

        public ProductController(ProductsServices service)
        {

            _service = service;

        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            SearchProductsDto searchProducts = _service.AddProduct(productDto);
            return CreatedAtAction(nameof(SearchId), new { id = searchProducts.Id }, searchProducts);
        }
        [HttpGet]
        public List<Product> SearchId([FromQuery] string name, [FromQuery] string center, [FromQuery] bool? status, [FromQuery] double? weight,
            [FromQuery] double? height, [FromQuery] double? lengths, [FromQuery] double? widths,
            [FromQuery] double? price, [FromQuery] int? amountOfProducts, [FromQuery] int? order)
        {
           return _service.FilterProduct(name, center, status, weight, height, lengths, widths, price, amountOfProducts, order);

    
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
