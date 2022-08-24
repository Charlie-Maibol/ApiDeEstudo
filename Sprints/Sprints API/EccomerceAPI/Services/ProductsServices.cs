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
        private IConfiguration _configuration;
        private CategoryContext _context;
        private ProductDao _dao;
        private IMapper _mapper;
       


        public ProductsServices(CategoryContext context, IMapper mapper, ProductDao dao, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _dao = dao;
            _configuration = configuration;
            

        }
        public SearchProductsDto AddProduct(CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            SubCategory sub = _context.SubCategories.FirstOrDefault(sub => sub.Id == productDto.subCategoryId);
            Category cat = _context.Categories.FirstOrDefault(cat => cat.Id == sub.CategoryId);
            if (cat.Status == false && sub.Status == false)
            {
               _dao.AddProduct(productDto);
            }           

            return _mapper.Map<SearchProductsDto>(productDto);
            
        }

        public List<SearchProductsDto> SearchId(int? Id, int pageNumber, int itensPerPage)
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
                return productDto;
            }
            return null;

        }

        public Result EditProduct(int id, EditProductDto Product)
        {
            var product = _dao.SearchProdId(id);
            if (product == null)
            {

                return Result.Fail("Produto não encontrado");
            }

            _dao.EditProduct(id, Product);
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
        public List<Product> FilterProduct(string name, string center,bool? status,double? weight,double? height,double? lengths,double? widths,
            double? price, int? amountOfProducts,int? order, int? itensPerPage, int? pageNumber)
        {
            var sql = "SELECT * FROM Products WHERE ";
            using var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();

            if(name != null)
            {
                sql += "Name LIKE \"%" + name + "%\" and ";
            }
            if (center != null)
            {
                sql += "DistributionCenter LIKE \"%" + center + "%\" and ";
            }
            if (status != null)
            {
                sql += "Status = @status and "; 
            }
            if (weight != null)
            {
                sql += "Weight = @peso and ";
            }
            if (height != null)
            {
                sql += "Height = @altura and ";
            }
            if (lengths != null)
            {
                sql += "Widths = @largura and ";
            }
            if (widths != null)
            {
                sql += "Lengths = @comprimento and "; 
            }
            if (amountOfProducts != null)
            {
                sql += "AmountOfProducts = @quantidade and ";
            }
            if (price != null)
            {
                sql += "Price = @valor and ";
            }
            if(name == null && center == null && price == null && amountOfProducts == null && widths == null && lengths == null && height == null && status == null
                && weight == null)
            {
                var wherePosition = sql.LastIndexOf("WHERE");
                sql = sql.Remove(wherePosition);
            }
            else
            {
                var andPosition = sql.LastIndexOf("and");
                sql = sql.Remove(andPosition);
            }
            if(order != null)
            {
                if(order != 1 && order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if(order == 1)
                {
                    sql += " ORDER BY Name OFFSET";
                }
                if(order == 2)
                {
                    sql += " ORDER BY Name DESC";
                }
            }

            var result = connection.Query<Product>(sql, new
            {
                Name = name,
                Status = status,
                DistributionCenter = center,
                Height = height,
                Weight = weight,
                Price = price,
                Lenght = widths,
                Widths = lengths,
                AmountOfProducts = amountOfProducts,
                Offset = (pageNumber - 1) * itensPerPage,
                PageSize = itensPerPage
            



            });
            return result.ToList();
        }

    }
        
}
