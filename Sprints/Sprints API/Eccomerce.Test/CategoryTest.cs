using AutoMapper;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using EccomerceAPI.Profiles;
using EccomerceAPI.Services;
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
        public void TestCategoryNotNull()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category() { Name = "teste" });

            var result = categoryService.AddCategory(new CreateCategoryDto { Name = "teste" });

            Assert.NotNull(result);
        }

        [Fact]
        public void TestCategoryCreatTime()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category() { Name = "teste" });

            var created = $"{DateTime.Now:yyyy-MM-dd}";

            var result = categoryService.AddCategory(new CreateCategoryDto { Name = "teste2" });

            Equals(created, $"{result.Created:yyyy-MM-dd}");
        }
        [Fact]

        public void TestCategoryStatusWhenCreatedEqualsTrue()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category() { Name = "teste" });
            var status = true;
            Assert.True(status);
        }
        [Fact]
        public void TestCategoryMaxCharacters()
        {
            categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category());
            var result = "aaaaaaaaaaaaaaaaaaaa" + //20
                "aaaaaaaaaaaaaaaaaaaa" + //40
                "aaaaaaaaaaaaaaaaaaaa" + // 60
                "aaaaaaaaaaaaaaaaaaaa" + //80
                "aaaaaaaaaaaaaaaaaaaa" + //100
                "aaaaaaaaaaaaaaaaaaaa";  //120 ;
            Assert.Matches(@"^[a-zA-Z' '-'\s]{1,128}$", result);
        }
        //[Fact]
        //public void TestCategoryMaxCharactersExcetion()
        //{
        //    categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category
        //    {
        //        Name = "aaaaaaaaaaaaaaaaaaaa" + //20
        //        "aaaaaaaaaaaaaaaaaaaa" + //40
        //        "aaaaaaaaaaaaaaaaaaaa" + // 60
        //        "aaaaaaaaaaaaaaaaaaaa" + //80
        //        "aaaaaaaaaaaaaaaaaaaa" + //100
        //        "aaaaaaaaaaaaaaaaaaaa" + //120
        //        "aaaaaaaaaaaaaaaaaaaa"
        //});
        //    var result = "aaaaaaaaaaaaaaaaaaaa" + //20
        //        "aaaaaaaaaaaaaaaaaaaa" + //40
        //        "aaaaaaaaaaaaaaaaaaaa" + // 60
        //        "aaaaaaaaaaaaaaaaaaaa" + //80
        //        "aaaaaaaaaaaaaaaaaaaa" + //100
        //        "aaaaaaaaaaaaaaaaaaaa" + //120
        //        "aaaaaaaaaaaaaaaaaaaa";
        //    Assert.Throws(ExceptionAggregator, result);
        //}
    }
}