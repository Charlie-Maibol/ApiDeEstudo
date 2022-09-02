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
        public List<Product> NullProducts(int? Id)
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

            return products;
        }

        public List<Product> FilterProduct(string name, string center, bool? status, double? weight, double? height, double? lengths, double? widths,
            double? price, int? amountOfProducts, int? order, int itensPerPage = 0, int pageNumber = 0)
        {
            var FilterSql = "SELECT * FROM Products WHERE ";
            var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();

            if (name != null)
            {
                FilterSql += "Name LIKE \"%" + name + "%\" and ";
            }
            if (center != null)
            {
                FilterSql += "DistributionCenter LIKE \"%" + center + "%\" and ";
            }
            if (status != null)
            {
                FilterSql += "Status = @status and ";
            }
            if (weight != null)
            {
                FilterSql += "Weight = @weight and ";
            }
            if (height != null)
            {
                FilterSql += "Height = @height and ";
            }
            if (widths != null)
            {
                FilterSql += "Widths = @widths and ";
            }
            if (lengths != null)
            {
                FilterSql += "Lengths = @lengths and ";
            }
            if (amountOfProducts != null)
            {
                FilterSql += "AmountOfProducts = @amountOfProducts and ";
            }
            if (price != null)
            {
                FilterSql += "Price = @price and ";
            }
            if (name == null && center == null && price == null && amountOfProducts == null && widths == null && lengths == null && height == null && status == null
                && weight == null)
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }
            if (order != null)
            {
                if (order != 1 && order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if (order == 1)
                {
                    FilterSql += " ORDER BY Name";
                }
                if (order == 2)
                {
                    FilterSql += " ORDER BY Name DESC";
                }
            }

            var result = connection.Query<Product>(FilterSql, new
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
