using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using EccomerceAPI.Data;

namespace EccomerceAPI.Services
{
    public class ProductsServices
    {

        private AppDbContext _productContext;
        private ProductDao _productDao;
        private IMapper _productMapper;

        public ProductsServices(AppDbContext context, IMapper mapper, ProductDao dao, IConfiguration configuration)
        {
            _productContext = context;
            _productMapper = mapper;
            _productDao = dao;



        }
        public SearchProductsDto AddProduct(CreateProductDto productDto)
        {
            Product product = _productMapper.Map<Product>(productDto);
            SubCategory sub = _productContext.SubCategories.FirstOrDefault(sub => sub.Id == productDto.subCategoryId);
            Category cat = _productContext.Categories.FirstOrDefault(cat => cat.Id == sub.CategoryId);
            if (cat.Status == true && sub.Status == true)
            {


                return _productDao.AddProduct(productDto);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
        public List<Product> GetProductsCenterID(int Id)
        {
            return _productContext.Products.Where(prod => prod.distribuitonCenterId == Id).ToList();
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
