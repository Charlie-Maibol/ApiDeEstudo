using AutoMapper;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Cart;
using EccomerceAPI.Data.Dtos.CartWithProducts;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using FluentResults;
using Newtonsoft.Json;
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
        private IProductDao _prodDao;

        public CartServices(IMapper mapper, CartDao dao, IProductDao prodDao)
        {
            _cartMapper = mapper;
            _cartDao = dao;
            _prodDao = prodDao;
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

        public CartWithProduct AddProduct(CreateCartWithProducts productCart)
        {
            var searchProd = _prodDao.SearchProdId(productCart.ProductId);
            if (searchProd == null)
            {
                return null;
            }

            var cart = _cartDao.GetCartId(productCart.CartId);
            if (cart == null)
            {
                return null;
            }
            var products = _cartMapper.Map<CreateCartWithProducts>(productCart);
            products.ProductName = searchProd.Name;
            products.IndividualPrice = searchProd.Price;

            var saveProducts = _cartMapper.Map<CartWithProduct>(products);

            var prodInCart = _cartDao.GetItemInCart(productCart);

            if (prodInCart == null)
            {
                if (searchProd.AmountOfProducts > 0 && searchProd.Status == true)
                {
                    for (int item = 0; item < productCart.AmountOfProducts; item++)
                    {
                        cart.CartWithProducts.Add(saveProducts);
                        _cartDao.SaveProducts(productCart);
                    }
                    SaveCart(cart);

                }

                if(searchProd.AmountOfProducts > 0 && searchProd.Status != true)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest); //produto inativo ou sem estoque
                }
                return saveProducts;

            }

            prodInCart.AmountOfProducts += productCart.AmountOfProducts;
            _cartDao.SaveProducts(products);
            SaveCart(cart);
            return prodInCart;

        }
        private void SaveCart(Cart cart)
        {
            var buscaTotais = _cartDao.NewProductPrice(cart);
            if (buscaTotais == null)
            {
                cart.TotalAmount = 0;
                cart.Totalprice = 0;
            }
            else
            {
                cart.TotalAmount = buscaTotais.TotalAmount;
                cart.Totalprice = buscaTotais.Totalprice;
            }

            _cartDao.SaveChangesCart();
        }


        public CartWithProduct RemoveProduct(CreateCartWithProducts remove)
        {

            var cart = _cartDao.GetCartId(remove.CartId);
            if (cart == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var getProdInCart = _cartDao.searchProdInCartId(remove.ProductId);
            var removeProdValidation = getProdInCart.AmountOfProducts -= remove.AmountOfProducts;


            if (removeProdValidation <= 0)
            {
                _cartDao.DeletProdutCart(getProdInCart.Id);
                _cartDao.SaveProducts(remove);

                SaveCart(cart);
            }
            else
            {
                cart.TotalAmount = removeProdValidation;
                var map = _cartMapper.Map<CreateCartWithProducts>(getProdInCart);

                _cartDao.SaveProducts(map);
                SaveCart(cart);
            }

            return getProdInCart;
        }
    }

}
