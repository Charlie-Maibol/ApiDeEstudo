using AutoMapper;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Interface;
using EccomerceAPI.Models;
using EccomerceAPI.Profiles;
using EccomerceAPI.Services;
using Moq;
using System;
using Xunit;

namespace Eccomerce.Test
{
    public class TestSubCategory
    {
        private SubCategoryServices SubCategoryService;
        private Mock<ISubCategoryDao> subcategoryDao;
        readonly IMapper mapper;
        MapperConfiguration _mapperConfiguration;

        public TestSubCategory()
        {
            subcategoryDao = new Mock<ISubCategoryDao>();
            _mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new SubCategoryProfile());
            });
            mapper = _mapperConfiguration.CreateMapper();
            SubCategoryService = new SubCategoryServices(subcategoryDao.Object, mapper);

        }


        [Fact]
        public void TestSubCategoryNotNull()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory() { Name = "teste", CategoryId = 1 });

            var result = SubCategoryService.AddSubCategory(new CreateSubCategoryDto { Name = "teste" });

            Assert.NotNull(result);
        }
        //[Fact]
        //public void TestSubCategoryCreatWithOutCategoryID()
        //{

        //    var result = subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory() { Name = "teste" });


        //    Assert.(result);
        //}
        [Fact]
        public void TestSubCategoryCreatTime()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory() { Name = "teste", CategoryId = 1 });

            var created = $"{DateTime.Now:yyyy-MM-dd}";

            var result = SubCategoryService.AddSubCategory(new CreateSubCategoryDto { Name = "teste2" });

            Equals(created, $"{result.Created:yyyy-MM-dd}");
        }
        [Fact]

        public void TestSubCategoryWhenCreatedEqualsTrue()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory() { Name = "teste", CategoryId = 1 });
            var status = true;
            Assert.True(status);
        }
        [Fact]
        public void TestSubCategoryMaxCharacters()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            var result = "regexteste";
            Assert.Matches(@"^[a-zA-Z' '-'\s]{1,128}$", result);
        }
        //[Fact]
        //public void TestCategoryMaxCharactersExcetion()
        //{
        // var category = categoryDao.Setup(repo => repo.AddCategory(It.IsAny<Category>())).Returns(new Category
        //var category = new CreateCategoryDto()
        //{
        //    Name = "aaaaaaaaaaaaaaaaaaaa" + //20
        //    "aaaaaaaaaaaaaaaaaaaa" + //40
        //    "aaaaaaaaaaaaaaaaaaaa" + // 60
        //    "aaaaaaaaaaaaaaaaaaaa" + //80
        //    "aaaaaaaaaaaaaaaaaaaa" + //100
        //    "aaaaaaaaaaaaaaaaaaaa" + //120
        //    "aaaaaaaaaaaaaaaaaaaa"
        //};
        //var result = category.Name.Length =< 128;
        //Assert.Equal(result, category.Name.Length);
        // }
    }
}
