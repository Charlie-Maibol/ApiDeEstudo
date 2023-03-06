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
        private CategoryServices categoryServices;
        private Mock<ICategoryDao> categoryDao;
        private Mock<ISubCategoryDao> subcategoryDao;
        private Mock<IProductDao> productDao;
        readonly IMapper mapper;
        MapperConfiguration mapperConfiguration;

        public CategoryTest()
        {
            categoryDao = new Mock<ICategoryDao>();
            subcategoryDao = new Mock<ISubCategoryDao>();
            productDao = new Mock<IProductDao>();
            mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new CategoryProfile());
            });
            mapper = mapperConfiguration.CreateMapper();
            categoryServices = new CategoryServices(categoryDao.Object, productDao.Object, subcategoryDao.Object, mapper);

        }


        [Fact]
        public void TestCategoryNotNull()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category() { Name = "teste" });

            var result = categoryServices.AddCategory(new CreateCategoryDto { Name = "teste" });

            Assert.NotNull(result);
        }

        [Fact]
        public void TestCategoryCreatTime()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category() { Name = "teste" });

            var created = $"{DateTime.Now:yyyy-MM-dd}";

            var result = categoryServices.AddCategory(new CreateCategoryDto { Name = "teste2" });

            Equals(created, $"{result.Created:yyyy-MM-dd}");
        }
        [Fact]

        public void TestCategoryStatusCreatedSucced()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category());
            var categoryStatusTest = new CreateCategoryDto()
            {
                Name = "Controle",

               
            };
            var controller = new CategoryController(categoryDao.Object, categoryServices);
            var result = (ObjectResult)controller.AddCategory(categoryStatusTest);

            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void TestCategoryMaxCharacters()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category());
            var categoryNameTest = new CreateCategoryDto()
            {
                Name = "aaaaaaaaaaaaaaaaaaaa" + // 20
                       "aaaaaaaaaaaaaaaaaaaa" +  // 40
                       "aaaaaaaaaaaaaaaaaaaa" + // 60 
                       "aaaaaaaaaaaaaaaaaaaa" + // 80
                       "aaaaaaaaaaaaaaaaaaaa" + // 100
                       "aaaaaaaaaaaaaaaaaaaa" + // 120
                       "aaaaaaaaaaaaaaaaaaaa"   // 140
            };
            var controller = new CategoryController(categoryDao.Object,categoryServices);
            var result = (ObjectResult)controller.AddCategory(categoryNameTest);

            Assert.Equal(400,result.StatusCode);
        }
        [Fact]
        public void TestCategoryMinCharactersExcetion()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category());
            var categoryNameTest = new CreateCategoryDto()
            {
                Name = "aa"
            };
            var controller = new CategoryController(categoryDao.Object, categoryServices);
            var result = (ObjectResult)controller.AddCategory(categoryNameTest);

            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public void TestCategoryCreatedWithStatusFalse()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category());
            var categoryStatusTest = new CreateCategoryDto()
            {
                Name = "aaaaaaaa",
                Status = false
            };
            var controller = new CategoryController(categoryDao.Object, categoryServices);
            var result = (ObjectResult)controller.AddCategory(categoryStatusTest);

            Assert.Equal(400, result.StatusCode);
        }
    }
}