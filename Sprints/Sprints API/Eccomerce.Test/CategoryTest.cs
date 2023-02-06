using AutoMapper;
using EccomerceAPI.Controllers;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using EccomerceAPI.Profiles;
using EccomerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Eccomerce.Test
{
    public class CategoryTest
    {
        private CategoryServices categoryService;
        private Mock<ICategoryDao> categoryDao;
        private Mock<ISubCategoryDao> subcategoryDao;
        private Mock<IProductDao> productDao;
        readonly IMapper mapper;
        MapperConfiguration _mapperConfiguration;

        public CategoryTest()
        {
            categoryDao = new Mock<ICategoryDao>();
            subcategoryDao = new Mock<ISubCategoryDao>();
            productDao = new Mock<IProductDao>();
            _mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new CategoryProfile());
            });
            mapper = _mapperConfiguration.CreateMapper();
            categoryService = new CategoryServices(categoryDao.Object, productDao.Object, subcategoryDao.Object, mapper);
        }


        [Fact]
        public void TestCreateCategory()
        {
            var controller = new CategoryController(categoryDao.Object, categoryService);
            var result = (ObjectResult)controller.AddCategory(new CreateCategoryDto { Name = "teste" });

            Assert.Equal(201, result.StatusCode);
        }
    }
}
