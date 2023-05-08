using EccomerceAPI.Data.Dtos.CartWithProducts;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{
    public class CartWithProductsProfile : AutoMapper.Profile
    {
        public CartWithProductsProfile()
        {
            CreateMap<CreateCartWithProducts, CartWithProduct>();
            CreateMap<CartWithProduct, CreateCartWithProducts>();
        }
    }
}
