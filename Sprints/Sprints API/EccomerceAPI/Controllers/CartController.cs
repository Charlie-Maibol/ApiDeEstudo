using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("[controller]")]
[ApiController]
public class CartController : ControllerBase
{


    private CartDao _cartDao;
    private CartServices _cartService;

    public CartController(CartServices service, CartDao cartDao)
    {
        _cartService = service;
        _cartDao = cartDao;
    }

    //[HttpPost]
    //public async Task<IActionResult> AddCenter([FromBody] CreateCartDto cartDto)
    //{
    //    SearchCartsDto searchCart = await _cartService.CreateCart(cartDto);
    //    return CreatedAtAction(nameof(SearchCartId), new { id = cartDto.Id }, cartDto);
    //}
   
        
    
}

