using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos.Cart;
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

    [HttpPost]
    public async Task<IActionResult> AddCenter([FromBody] CreateCartDto cartDto)
    {
        SearchCartsDto searchCart = await _cartService.CreateCart(cartDto);
        return CreatedAtAction(nameof(SearchCenterId), new { id = cartDto.Id }, cartDto);
    }
    [HttpGet("{Id}")]
    public IActionResult SearchCenterId(int? Id)
    {
        List<SearchCartsDto> cartDto = _cartService.SearchCartId(Id);
        if (cartDto != null)
        {
            return Ok(cartDto);

        }
        return NotFound();
    }
    [HttpGet("filter")]
    public List<Cart> FilterCart([FromBody] FilterCartsDto fIlterDto)
    {
        return _CartDao.FilterCart(fIlterDto);



    }
    [HttpPut("{Id}")]
    public IActionResult EditCart(int Id, [FromBody] EditCartsDto Center)
    {
        Result result = _cartService.EditCart(Id, Center);
        if (result.IsFailed)
        {
            return NotFound();
        }

        return NoContent();
    }
    [HttpDelete("{Id}")]

    public IActionResult DeletCart(int Id)
    {
        Result result = _cartService.DeletCart(Id);
        if (result.IsFailed)
        {
            return NotFound();
        }
        return Ok();
    }
}

