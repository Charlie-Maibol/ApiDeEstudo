﻿using AutoMapper;
using AutoMapper.Configuration;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Models;
using FluentResults;
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
        private Mapper _cartMapper;
        public CartServices(Mapper mapper, CartDao dao, IConfiguration configuration)
        {
            _cartMapper = mapper;
            _cartDao = dao;

        }
        public async Task<SearchCartsDto> CreateCart(CreateCartDto cartDto)
        {

            var street = await GetAdress(cartDto.ZipCode);
            if (street.Street == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                _cartDao.AddCart(cartDto, street);

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

        private bool UniqueAddress(Cart cart)
        {
            CartFilterDto filter = new();
            var cartList = _cartDao.Filter(filter);
            string address = cart.Street;
            address += cart.StreetNumber;
            address += cart.AddComplemente;

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

        internal Result EditCart(int id, EditCartsDto center)
        {
            throw new NotImplementedException();
        }

        internal Result DeletCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}