using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using EccomerceAPI.Interface;

namespace EccomerceAPI.Services
{
    public class ProductsServices
    {

        private IProductDao _productDao;
        private IMapper _productMapper;

        public ProductsServices(IMapper mapper, IProductDao dao, IConfiguration configuration)
        {
            _productMapper = mapper;
            _productDao = dao;

        }
        public SearchProductsDto AddProduct(CreateProductDto productDto)
        {
            var validation = _productDao.GetSubCategoryID(productDto);
            if(productDto.Name.Length < 3)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if(validation.Status == false)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if(validation.Status == true)
            {
                _productDao.AddProduct(productDto);
            }
            return null;

        }

        public List<SearchProductsDto> SearchProdId(int? Id)
        {
            List<Product> products;

            products = _productDao.NullProducts(Id);
            if (products != null)
            {
                List<SearchProductsDto> productDto = _productMapper.Map<List<SearchProductsDto>>(products);
                return productDto;
            }
            return null;

        }
        public Result EditProduct(int id, EditProductDto ProductDto)
        {
            var product = _productDao.SearchProdId(id);
            if (product == null)
            {

                return Result.Fail("Produto não encontrado");
            }
            _productMapper.Map(ProductDto, product);
            _productDao.EditProduct(id, product);
            return Result.Ok();
        }
        public Result DeletProduct(int id)
        {
            var product = _productDao.SearchProdId(id);
            if (product == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _productDao.DeleteProduct(product);
            return Result.Ok();
        }
    }

}
