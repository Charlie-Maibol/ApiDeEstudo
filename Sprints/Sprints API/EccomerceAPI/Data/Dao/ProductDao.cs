using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using EccomerceAPI.Data.Dtos;
using System;

namespace EccomerceAPI.Data.productDao
{
    public class ProductDao
    {
        private AppDbContext _productContext;
        private IMapper _mapper;
        private IConfiguration _configuration;
       

        public ProductDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _productContext = context;
            _mapper = mapper;
            _configuration = configuration;
            
        }
        public SearchProductsDto AddProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
            return _mapper.Map<SearchProductsDto>(product);
        }
        public Product CenterID(int id)
        {

            return _productContext.Products.FirstOrDefault(p => p.distribuitonCenterId == id);
        }
        public void DeleteProduct(Product product)
        {
            _productContext.Remove(product);
            _productContext.SaveChanges();
        }
        public void EditProduct(int id, Product product)
        {
                       
            _productContext.SaveChanges();
        }
        public Product SearchProdId(int id)
        {
            
            return _productContext.Products.FirstOrDefault(p => p.Id == id);
        }
        public List<Product> NullProducts(int? Id)
        {
            List<Product> products;
            if (Id == null)
            {
                products = _productContext.Products.ToList();
            }
            else
            {
                products = _productContext.Products.Where(p => p.Id == Id).ToList();


            }

            return products;
        }
        private static bool Null(ProductFIlterDto productFIlterDto)
        {
            return productFIlterDto.name == null && productFIlterDto.center == null && productFIlterDto.price == null && productFIlterDto.amountOfProducts == null
            && productFIlterDto.widths == null && productFIlterDto.lengths == null && productFIlterDto.height == null && productFIlterDto.status == null
            && productFIlterDto.weight == null;
        }
        public List<Product> FilterProduct(ProductFIlterDto productFIlterDto)
        {
            var FilterSql = "SELECT * FROM Products WHERE ";
            var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();

            if (productFIlterDto.name != null)
            {
                FilterSql += "Name LIKE \"%" + productFIlterDto.name + "%\" and ";
            }
            if (productFIlterDto.center != null)
            {
                FilterSql += "DistributionCenter LIKE \"%" + productFIlterDto.center + "%\" and ";
            }
            if (productFIlterDto.status != null)
            {
                FilterSql += "Status = @status and ";
            }
            if (productFIlterDto.weight != null)
            {
                FilterSql += "Weight = @weight and ";
            }
            if (productFIlterDto.height != null)
            {
                FilterSql += "Height = @height and ";
            }
            if (productFIlterDto.widths != null)
            {
                FilterSql += "Widths = @widths and ";
            }
            if (productFIlterDto.lengths != null)
            {
                FilterSql += "Lengths = @lengths and ";
            }
            if (productFIlterDto.amountOfProducts != null)
            {
                FilterSql += "AmountOfProducts = @amountOfProducts and ";
            }
            if (productFIlterDto.price != null)
            {
                FilterSql += "Price = @price and ";
            }
            if (Null(productFIlterDto))
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }
            if (productFIlterDto.order != null)
            {
                if (productFIlterDto.order != 1 && productFIlterDto.order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if (productFIlterDto.order == 1)
                {
                    FilterSql += " ORDER BY Name";
                }
                if (productFIlterDto.order == 2)
                {
                    FilterSql += " ORDER BY Name DESC";
                }
            }

            var result = connection.Query<Product>(FilterSql, new
            {
                Name = productFIlterDto.name,
                Status = productFIlterDto.status,
                DistributionCenter = productFIlterDto.center,
                Height = productFIlterDto.height,
                Weight = productFIlterDto.weight,
                Price = productFIlterDto.price,
                Lenght = productFIlterDto.widths,
                Widths = productFIlterDto.lengths,
                AmountOfProducts = productFIlterDto.amountOfProducts,


            });
            if (productFIlterDto.pageNumber > 0 && productFIlterDto.itensPerPage > 0 && productFIlterDto.itensPerPage <= 10)
            {
                var pages = result.Skip((productFIlterDto.itensPerPage - 1) * productFIlterDto.pageNumber)
                    .Take(productFIlterDto.pageNumber).ToList();
                connection.Close();
                return pages;

            }

            var limit = result.Skip(0).Take(25).ToList();
            connection.Close();
            return limit;

        }


    }
}
