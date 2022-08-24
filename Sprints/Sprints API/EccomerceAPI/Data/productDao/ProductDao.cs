using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data;
using EccomerceAPI.Models;
using System.Linq;

namespace EccomerceAPI.Data.productDao
{
    public class ProductDao
    {
        private CategoryContext _context;
        private IMapper _mapper;

        public ProductDao(CategoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public void AddProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();
            _mapper.Map<SearchProductsDto>(product);
        }
        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
        public void EditProduct(int id, EditProductDto productDto)
        {
            _mapper.Map<Product>(productDto);           
            _context.SaveChanges();
        }
        public Product SearchProdId(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
