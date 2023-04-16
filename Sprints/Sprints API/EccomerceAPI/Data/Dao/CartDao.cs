using AutoMapper;
using Dapper;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceAPI.Data.Dao
{
    public class CartDao
    {

        private AppDbContext _context;
        private Mapper _mapper;
        private IConfiguration _configuration;

        public CartDao(AppDbContext context, Mapper mapper, IConfiguration configuration)
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

        public List<Cart> Filter(CartFilterDto filterDto)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();
            var queryArgs = new DynamicParameters();
            var FilterSql = "SELECT c.id, c.addComplemente, c.status, c.city, c.uf, c.zipCode, c.street, c.streetNumber," +
                "d.neighbourhood as neighbourhood, " +
                "p.name as Product, p.distribuitonCenterId " +
                "FROM Carts c " +
                "INNER JOIN Products p ON c.id = p.distribuitonCenterId " +
                "WHERE ";

            if (filterDto.addComplemente != null)
            {
                FilterSql += "c.addComplemente LIKE CONCAT('%',@addComplemente,'%') and ";
                queryArgs.Add("AddComplemente", filterDto.addComplemente);
            }
            if (filterDto.status != null)
            {

                FilterSql += "c.status = @status and ";
                queryArgs.Add("Status", filterDto.status);
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
               }, queryArgs, splitOn: "productId")
               .Skip((filterDto.itensPerPage - 1) * filterDto.pageNumber)
               .Take(filterDto.pageNumber).ToList();

            connection.Close();
            return result;

        }

    }


}

