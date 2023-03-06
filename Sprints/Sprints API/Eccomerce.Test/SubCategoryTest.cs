using AutoMapper;
using EccomerceAPI.Controllers;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using EccomerceAPI.Profiles;
using EccomerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
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
        public void TestSubCategoryNotNull_true()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            subcategoryDao.Setup(repo => repo.GetCategoryID(It.IsAny<SubCategory>())).Returns(new Category() { Status = true });
            var result = SubCategoryService.AddSubCategory(new CreateSubCategoryDto { Name = "teste", CategoryId = 1 });

            Assert.NotNull(result);
        }
        [Fact]
        public void TestSubCategoryCreatWithOutCategoryID_400()
        {

            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            var subStatusTest = new CreateSubCategoryDto()
            {
                Name = "Controle",

            };
            var controller = new SubCategoryController(subcategoryDao.Object, SubCategoryService);
            var result = (ObjectResult)controller.AddSubCategory(subStatusTest);

            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public void TestSubCategoryCreatTime_true()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            subcategoryDao.Setup(repo => repo.GetCategoryID(It.IsAny<SubCategory>())).Returns(new Category() { Status = true });
            var created = $"{DateTime.Now:yyyy-MM-dd}";

            var result = SubCategoryService.AddSubCategory(new CreateSubCategoryDto { Name = "teste2", CategoryId = 2 });

            Equals(created, $"{result.Created:yyyy-MM-dd}");
        }
        [Fact]

        public void TestSubCategoryCreatedSucced_200()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            subcategoryDao.Setup(repo => repo.GetCategoryID(It.IsAny<SubCategory>())).Returns(new Category() { Status = true});
            var subStatusTest = new CreateSubCategoryDto()
            {
                Name = "Controle",
                CategoryId = 1


            };
            var controller = new SubCategoryController(subcategoryDao.Object, SubCategoryService);
            var result = (ObjectResult)controller.AddSubCategory(subStatusTest);

            Assert.Equal(200, result.StatusCode);
        }
        [Fact]

        public void TestSubCategoryCreatedWithStatusFalse_400()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            subcategoryDao.Setup(repo => repo.GetCategoryID(It.IsAny<SubCategory>())).Returns(new Category() { Status = true });
            var subStatusTest = new CreateSubCategoryDto()
            {
                Name = "Controle",
                CategoryId = 1,
                Status = false


            };
            var controller = new SubCategoryController(subcategoryDao.Object, SubCategoryService);
            var result = (ObjectResult)controller.AddSubCategory(subStatusTest);

            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public void TestCategoryMaxCharacter_400()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());

            var subStatusTest = new CreateSubCategoryDto()
            {
                Name = "aaaaaaaaaaaaaaaaaaaa" + //20
                "aaaaaaaaaaaaaaaaaaaa" + //40
                "aaaaaaaaaaaaaaaaaaaa" + // 60
                "aaaaaaaaaaaaaaaaaaaa" + //80
                "aaaaaaaaaaaaaaaaaaaa" + //100
                "aaaaaaaaaaaaaaaaaaaa" + //120
                "aaaaaaaaaaaaaaaaaaaa",  //140
                CategoryId = 3
            };
            var controller = new SubCategoryController(subcategoryDao.Object, SubCategoryService);
            var result = (ObjectResult)controller.AddSubCategory(subStatusTest);

            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public void TestSubCategorydWithCategoryStatusFalse_400()
        {
            
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());
            subcategoryDao.Setup(repo => repo.GetCategoryID(It.IsAny<SubCategory>())).Returns(new Category() { Status = false });
            var subStatusTest = new CreateSubCategoryDto()
            {
                Name = "Controle",
                CategoryId = 1,
            };
            var controller = new SubCategoryController(subcategoryDao.Object, SubCategoryService);
            var result = (ObjectResult)controller.AddSubCategory(subStatusTest);

            Assert.Equal(400, result.StatusCode);
        }

            [Fact]
        public void TestCategoryMinCharacter_400()
        {
            subcategoryDao.Setup(repo => repo.AddSubCategory(It.IsAny<SubCategory>())).Returns(new SubCategory());

            var subStatusTest = new CreateSubCategoryDto()
            {
                Name = "aa", 
                CategoryId = 3
            };
            var controller = new SubCategoryController(subcategoryDao.Object, SubCategoryService);
            var result = (ObjectResult)controller.AddSubCategory(subStatusTest);

            Assert.Equal(400, result.StatusCode);
        }
    }
}
