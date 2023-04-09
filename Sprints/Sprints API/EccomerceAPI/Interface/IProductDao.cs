using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Models;
using System.Collections.Generic;

namespace EccomerceAPI.Interface
{
    public interface IProductDao
    {
        SearchProductsDto AddProduct(CreateProductDto productDto);
        Product CenterID(int id);
        void DeleteProduct(Product product);
        void EditProduct(int id, Product product);
        Product SearchProdId(int id);
        List<Product> NullProducts(int? Id);
        List<Product> FilterProduct(CartFilterDto productFIlterDto);
        List<Product> GetProductsCenterID(int Id);
        IEnumerable<Product> GetAll();
        SubCategory GetSubCategoryID(CreateProductDto productDto);
    }
}
