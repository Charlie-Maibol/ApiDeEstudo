using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Models;

namespace EccomerceAPI.Profiles
{


    public class CartProfile : AutoMapper.Profile
    {

        public CartProfile()
        {
            CreateMap<CreateCartDto, Cart>();
            CreateMap<Cart, SearchCartsDto>();
            CreateMap<EditCartsDto, Cart>();

        }

    }
}
