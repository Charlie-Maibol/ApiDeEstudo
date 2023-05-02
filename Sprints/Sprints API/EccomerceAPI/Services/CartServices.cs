using AutoMapper;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Data.Dtos.CartWithProducts;
using EccomerceAPI.Models;
using FluentResults;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EccomerceAPI.Services
{
    public class CartServices
    {
        private CartDao _cartDao;
        private IMapper _cartMapper;
        public CartServices(IMapper mapper, CartDao dao, IConfiguration configuration)
        {
            _cartMapper = mapper;
            _cartDao = dao;

        }
        public async Task<Cart> CreateCart(CreateCartDto cartDto)
        {

            var street = await GetAdress(cartDto.ZipCode);

            if (street.Street == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                if (UniqueAddress(street))
                {
                    _cartDao.AddCart(cartDto, street);
                }

            }
            return null;
        }

        public async Task<Cart> GetAdress(string cep)
        {
            HttpClient client = new HttpClient();
            var requisition = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var json = await requisition.Content.ReadAsStringAsync();
            Cart cart = new Cart();
            var viacep = JsonConvert.DeserializeObject<CartViaCepDto>(json);
            CartViaCep(cart, viacep);
            return cart;

        }

        private bool UniqueAddress(Cart cartDto)
        {
            CartFilterDto filter = new();
            var cartList = _cartDao.CartFilter(filter);
            string address = cartDto.Street;
            address += cartDto.StreetNumber;
            address += cartDto.AddComplemente;

            foreach (var a in cartList)
            {
                string addressComplet = a.Street;
                addressComplet += a.StreetNumber;
                addressComplet += a.AddComplemente;
                if (address == addressComplet)
                {
                    return false;
                }

            }

            return true;
        }

        private static void CartViaCep(Cart cart, CartViaCepDto viacep)
        {
            cart.ZipCode = viacep.cep;
            cart.Street = viacep.logradouro;
            cart.UF = viacep.uf;
            cart.Neighbourhood = viacep.bairro;
            cart.City = viacep.localidade;
        }


        public Result DeletCart(int id)
        {
            var cart = _cartDao.GetCartID(id);
            if (cart == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _cartDao.DeleteCart(cart);
            return Result.Ok();
        }

        internal object AddProduct(CreateCartWithProducts product)
        {
            throw new NotImplementedException();
        }

        internal object RemoveProduct(CreateCartWithProducts remove)
        {
            throw new NotImplementedException();
        }
    }
}
