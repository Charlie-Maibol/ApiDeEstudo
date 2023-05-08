using AutoMapper;
using Dapper;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Data.Dtos.CartWithProducts;
using EccomerceAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace EccomerceAPI.Data.Dao
{
    public class CartDao
    {

        private AppDbContext _context;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public CartDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        internal void AddCart(CreateCartDto cartDto, Cart street)
        {

            var cart = _mapper.Map<Cart>(cartDto);
            cart.Street = street.Street;
            cart.Neighbourhood = street.Neighbourhood;
            cart.UF = street.UF;
            cart.City = street.City;


            _context.Carts.Add(cart);
            _context.SaveChanges();
        }
        internal object GetCartID(int Id)
        {
            return _context.Carts.FirstOrDefault(cart => cart.Id == Id);
        }

        private static bool FilterIsNull(CartFilterDto filterDto)
        {
            return filterDto.addComplemente == null && filterDto.city == null && filterDto.UF == null
            && filterDto.zipCode == null && filterDto.street == null && filterDto.streetNumber == null && filterDto.status == null
            && filterDto.neighbourhood == null;
        }

        public List<Cart> CartFilter(CartFilterDto filterDto)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();
            var queryArgs = new DynamicParameters();
            var FilterSql = "SELECT c.id, c.addComplemente, c.city, c.uf, c.zipCode, c.street, c.streetNumber," +
                "c.neighbourhood as neighbourhood, " +
                "p.Id as Product, p.Id " +
                "FROM Carts c " +
                "INNER JOIN Products p ON c.id = p.Id " +
                "WHERE ";

            if (filterDto.addComplemente != null)
            {
                FilterSql += "c.addComplemente LIKE CONCAT('%',@addComplemente,'%') and ";
                queryArgs.Add("AddComplemente", filterDto.addComplemente);
            }
            if (filterDto.city != null)
            {
                FilterSql += "c.city LIKE CONCAT('%',@city,'%') and ";
                queryArgs.Add("City", filterDto.city);
            }
            if (filterDto.UF != null)
            {
                FilterSql += "c.uf LIKE CONCAT('%',@uf,'%') and ";
                queryArgs.Add("UF", filterDto.UF);
            }
            if (filterDto.zipCode != null)
            {
                FilterSql += "c.zipCode LIKE CONCAT('%',@zipCode,'%') and ";
                queryArgs.Add("ZipCode", filterDto.zipCode);
            }
            if (filterDto.street != null)
            {
                FilterSql += "c.street LIKE CONCAT('%',@street,'%') and ";
                queryArgs.Add("Street", filterDto.street);
            }
            if (filterDto.streetNumber != null)
            {

                FilterSql += "c.streetNumber = @streetNumber and ";
                queryArgs.Add("StreetNumber", filterDto.streetNumber);
            }
            if (filterDto.neighbourhood != null)
            {
                FilterSql += "c.neighbourhood LIKE CONCAT('%',@neighbourhood,'%') and ";
                queryArgs.Add("Neighbourhood", filterDto.neighbourhood);
            }
            if (FilterIsNull(filterDto))
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }



            var result = connection.Query<Cart, Product, Cart>
               (FilterSql, (cart, product) =>
               {
                   cart.Id = product.Id;
                   return cart;
               }, queryArgs, splitOn: "Id")
               .Skip((filterDto.itensPerPage - 1) * filterDto.pageNumber)
               .Take(filterDto.pageNumber).ToList();

            connection.Close();
            return result;

        }

        internal void DeleteCart(object cart)
        {

            _context.Remove(cart);
            _context.SaveChanges();
        }


        internal List<Cart> Nullcart(int? Id)
        {
            List<Cart> carts;
            if (Id == null)
            {
                carts = _context.Carts.ToList();
            }
            else
            {
                carts = _context.Carts.Where(c => c.Id == Id).ToList();


            }

            return carts;
        }

        internal object GetProdutCart(int Id)
        {
            return _context.CartWithProducts.FirstOrDefault(prodCart => prodCart.Id == Id);
        }
        public CartWithProduct GetItemInCart(CreateCartWithProducts getProd)
        {
            var jukinha = _context.CartWithProducts.SingleOrDefault(
                c => c.CartId == getProd.CartId
                && c.ProductId == getProd.ProductId);

            return jukinha;
        }

        public Cart GetCartId(int cartId)
        {
            return _context.Carts.FirstOrDefault(cart => cart.Id == cartId);
           
        }
        public List<Product> GetProductActive(int Id)
        {
            List<Product> products = _context.Products.Where(prod => prod.Id == Id && prod.Status == true).ToList();
            return products;
        }

        public CreateCartWithProducts SaveProducts(CreateCartWithProducts saveProducts)
        {
            _context.SaveChanges();
            return saveProducts;
        }

        public Cart NewProductPrice(Cart cart)
        {
            var sql = " SELECT  P.CartId as cartId," +
                "               sum(P.AmountOfProducts) as AmountOfProducts," +
                "               sum(P.IndividualPrice * P.AmountOfProducts) as Totalprice" +
                "       FROM cartwithproducts P" +
                "       WHERE  P.CartId = @id" +
                "       GROUP BY  P.CartId";

            Console.WriteLine(sql);
            using (var conection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection")))
            {
                var result = conection.Query<TotalProductsIncart>(sql.ToString(), cart).FirstOrDefault();

                var map = _mapper.Map<Cart>(result);
                if (map == null)
                {
                    return null;
                }
                map.TotalAmount = result.AmountOfProducts;
                map.Totalprice = result.totalPrice;

                return map;
            }
        }

        public void SaveChangesCart()
        {
            _context.SaveChanges(); 
        }

        public CartWithProduct searchProdInCartId(int id)
        {
            return _context.CartWithProducts.FirstOrDefault(p => p.Id == id);
        }

        internal void DeletProdutCart(int id)
        {
            var prodInCart = searchProdInCartId(id);
            _context.Remove(prodInCart);
        }
    }


}

