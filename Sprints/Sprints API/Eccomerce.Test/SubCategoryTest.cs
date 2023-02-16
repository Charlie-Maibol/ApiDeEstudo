using AutoMapper;
using EccomerceAPI.Data.Dtos.SubCategories;
using EccomerceAPI.Models;
using EccomerceAPI.Profiles;
using EccomerceAPI.Services;
using Moq;
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


    }
}
