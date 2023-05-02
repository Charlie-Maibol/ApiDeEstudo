using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Data.Dtos.CartWithProducts;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    public async Task<Cart> AddCart([FromBody] CreateCartDto cartDto)
    {
        return await _cartService.CreateCart(cartDto); 
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCart(int id)
    {

        Result result = _cartService.DeletCart(id);
        if (result.IsFailed) return NotFound("Carrinho não encontrado");
        return NoContent();

    }
    [HttpPost("add")]
    public IActionResult AddProduct([FromBody] CreateCartWithProducts product)
    {
        var result = _cartService.AddProduct(product);
        if (result == null) return BadRequest();
        return Ok(result);

    }

    [HttpPut("remove")]
    public IActionResult RemoveProduto(CreateCartWithProducts remove)
    {
        object result = _cartService.RemoveProduct(remove);
        if (result == null) return BadRequest();
        return Ok(result);
    }




}

