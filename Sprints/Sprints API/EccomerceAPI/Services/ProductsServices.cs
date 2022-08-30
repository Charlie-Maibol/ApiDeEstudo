using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using FluentResults;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using EccomerceAPI.Data;

namespace EccomerceAPI.Services
{
    public class ProductsServices
    {
        
        private AppDbContext _context;
        private ProductDao _dao;
        private IMapper _mapper;
       


        public ProductsServices(AppDbContext context, IMapper mapper, ProductDao dao, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _dao = dao;
            
            

        }
        public SearchProductsDto AddProduct(CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            SubCategory sub = _context.SubCategories.FirstOrDefault(sub => sub.Id == productDto.subCategoryId);
            Category cat = _context.Categories.FirstOrDefault(cat => cat.Id == sub.CategoryId);
            if (cat.Status == true && sub.Status == true)
            {
                
               
                return _dao.AddProduct(productDto);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            
        }

        public List<SearchProductsDto> SearchProdId(int? Id)
        {
            List<Product> products;

            if (Id == null)
            {
                products = _context.Products.ToList();
            }
            else
            {
                products = _context.Products.Where(p => p.Id == Id).ToList();
                

            }
            if (products != null)
            {
                List<SearchProductsDto> productDto = _mapper.Map<List<SearchProductsDto>>(products);
                return productDto;
            }
            return null;

        }

        public Result EditProduct(int id, EditProductDto ProductDto)
        {
            var product = _dao.SearchProdId(id);
            if (product == null)
            {

                return Result.Fail("Produto não encontrado");
            }
            _mapper.Map(ProductDto, product);
            _dao.EditProduct(id, product);
            return Result.Ok();
        }
        public Result DeletProduct(int id)
        {
            var product = _dao.SearchProdId(id);
            if (product == null)
            {
                return Result.Fail("Produto não encontrado");
            }
           _dao.DeleteProduct(product);
            return Result.Ok();
        }
        

    }
    
}
