using AutoMapper;
using AutoMapper.Configuration;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Data.Dtos.Products;
using Microsoft.EntityFrameworkCore;
using System;
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

        internal void AddProduct(CreateCartDto cartDto)
        {
            throw new NotImplementedException();
        }

        internal object Filter(DistributionCenterFilterDto filter)
        {
            throw new NotImplementedException();
        }

        internal object GetCartID(int Id)
        {
            return _context.Carts.FirstOrDefault(cart => cart.Id == Id);
        }
    }
}
