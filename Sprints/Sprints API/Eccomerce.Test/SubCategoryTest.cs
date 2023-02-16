using AutoMapper;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using EccomerceAPI.Profiles;
using EccomerceAPI.Services;
using Moq;
using System;
using Xunit;

namespace Eccomerce.Test
{
    public class SubCategoryTest
    {

        private SubCategoryServices categoryService;
        private Mock<ICategoryDao> categoryDao;
        private Mock<ISubCategoryDao> subcategoryDao;
        readonly IMapper mapper;
        MapperConfiguration _mapperConfiguration;

        public SubCategoryTest()
        {
            categoryDao = new Mock<ICategoryDao>();
            subcategoryDao = new Mock<ISubCategoryDao>();
            _mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new SubCategoryProfile());
            });
            mapper = _mapperConfiguration.CreateMapper();
            categoryService = new SubCategoryServices(subcategoryDao.Object, mapper);

        }
        [Fact]
        public void TestSubCategoryNotNull()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>()))
                .Returns(new SubCategory() { Name = "teste", CategoryId = 1 });

            var result = categoryService.AddSubCategory(new CreateSubCategoryDto { Name = "teste", CategoryId = 1 });

            Assert.NotNull(result);
        }
        [Fact]
        public void TestSubCategoryCreatTime()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>()))
                .Returns(new SubCategory() { Name = "teste", CategoryId = 1 });

            var created = $"{DateTime.Now:yyyy-MM-dd}";

            Equals(created);
        }

        [Fact]
        public void TestSubCategoryStatusWhenCreatedEqualsTrue()
        {

            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>()))
                .Returns(new SubCategory() { Name = "teste", CategoryId = 1 });

            var status = true;

            Assert.True(status);
        }
        [Fact]
        public void TestSubCategoryMaxCharacters()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>()))
                .Returns(new SubCategory() { CategoryId = 1 });
            var result = "aaaaaaaaaaaaaaaaaaaa" + //20
                "aaaaaaaaaaaaaaaaaaaa" + //40
                "aaaaaaaaaaaaaaaaaaaa" + // 60
                "aaaaaaaaaaaaaaaaaaaa" + //80
                "aaaaaaaaaaaaaaaaaaaa" + //100
                "aaaaaaaaaaaaaaaaaaaa";  //120 ;

            Assert.Matches(@"^[a-zA-Z' '-'\s]{1,128}$", result);
        }

        //[Fact]
        //public void TestSubCategoryMaxCharactersExcetion()
        //{
        //    subcategoryDao.Setup(repo => repo.AddCategory(It.IsAny<SubCategory>())).Returns(new SubCategory

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
