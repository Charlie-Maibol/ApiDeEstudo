using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data;
using EccomerceAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace EccomerceAPI.Data.productDao
{
    public class ProductDao
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public ProductDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public SearchProductsDto AddProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return _mapper.Map<SearchProductsDto>(product);
        }
        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
        public void EditProduct(int id, Product product)
        {
                       
            _context.SaveChanges();
        }
        public Product SearchProdId(int id)
        {
            
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> FilterProduct(string name, string center, bool? status, double? weight, double? height, double? lengths, double? widths,
            double? price, int? amountOfProducts, int? order, int itensPerPage = 0, int pageNumber = 0)
        {
            var sql = "SELECT * FROM Products WHERE ";
            using var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();

            if (name != null)
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
                sql += "Weight = @weight and ";
            }
            if (height != null)
            {
                sql += "Height = @height and ";
            }
            if (widths != null)
            {
                sql += "Widths = @widths and ";
            }
            if (lengths != null)
            {
                sql += "Lengths = @lengths and ";
            }
            if (amountOfProducts != null)
            {
                sql += "AmountOfProducts = @amountOfProducts and ";
            }
            if (price != null)
            {
                sql += "Price = @price and ";
            }
            if (name == null && center == null && price == null && amountOfProducts == null && widths == null && lengths == null && height == null && status == null
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
            if (order != null)
            {
                if (order != 1 && order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if (order == 1)
                {
                    sql += " ORDER BY Name";
                }
                if (order == 2)
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


            });
            if (pageNumber > 0 && itensPerPage > 0 && itensPerPage <= 10)
            {
                var pages = result.Skip((itensPerPage - 1) * pageNumber).Take(pageNumber).ToList();
                connection.Close();
                return pages;

            }

            var limit = result.Skip(0).Take(25).ToList();
            connection.Close();
            return limit;

        }

    }
}
