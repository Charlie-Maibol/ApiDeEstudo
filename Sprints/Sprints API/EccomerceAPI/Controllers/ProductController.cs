using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceAPI.Controllers
{

    [ApiController]
    [Route("{controller}")]
    public class ProductController : ControllerBase
    {

        private CategoryContext _context;
        private IMapper _mapper;
        

        public ProductController(CategoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchId), new { product.Id }, product);
        }

        [HttpGet("searchId/")]
        public IActionResult SearchId([FromQuery] int? Id = null, [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {
            List<Product> products;

            if (Id == null)
            {
                products = _context.Products.ToList();
            }

            else
            {
                products = _context.Products.Where(cat => cat.Id == Id)
                        .Skip((pageNumber - 1) * itensPerPage)
                        .Take(itensPerPage).ToList();
                List<SearchProductsDto> productDto = _mapper.Map<List<SearchProductsDto>>(products);

            }
            if (products != null)
            {
                List<SearchProductsDto> productDto = _mapper.Map<List<SearchProductsDto>>(products);
                return Ok(products);
            }

            return NotFound();

    
        }
        [HttpPut("{ID}")]
        public IActionResult EditProduct(int Id, [FromBody] EditProductDto Product)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == Id);
            if (product == null)
            {

                return NotFound();
            }
            _mapper.Map(Product, product);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{ID}")]
        
        public IActionResult DeletProduct(int ID)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == ID);
            if (product == null)
            {

                return NotFound();
            }
            _context.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
