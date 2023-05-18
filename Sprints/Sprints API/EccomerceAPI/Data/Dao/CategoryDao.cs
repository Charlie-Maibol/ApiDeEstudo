using AutoMapper;
using Dapper;
using Eccomerce.Test;
using EccomerceAPI.Controllers;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace EccomerceAPI.Data.Dao
{
    public class CategoryDao : ICategoryDao
    {


        private AppDbContext _context;
        private IMapper _mapper;
        private IConfiguration _configuration;
        private readonly ILogger<CategoryDao> logger;

        public CategoryDao(AppDbContext context, IMapper mapper, IConfiguration configuration, ILogger<CategoryDao> logger)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            this.logger = logger;
        }

        public Category AddCategory(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();
            logger.LogInformation($"#### Dao - Criando categoria. ####");
            return category;
        }

        public Result ListCategories(int pageNumber, int itensPerPage, int? Id)
        {
            List<Category> categories;

            if (Id == null)
            {
                logger.LogInformation($"#### Dao - Buscando todas as categoria. ####");
                categories = _context.Categories.ToList();
            }
            else
            {
                categories = _context.Categories.Where(cat => cat.Id == Id)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> category = _mapper.Map<List<SearchCategoriesDto>>(categories);
                logger.LogInformation($"#### Dao - Buscando categoria por Id. ####");

            }
            if (categories != null)
            {
                List<SearchCategoriesDto> category = _mapper.Map<List<SearchCategoriesDto>>(categories);
                logger.LogInformation($"#### Dao - Categoria inexistente, exibir tudo. ####");
                return Result.Ok();
            }
            return null;
        }
        public void DeleteCategory(int iD)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == iD);

            _context.Remove(category);
            _context.SaveChanges();
            logger.LogInformation($"#### Dao - Deletando categoria. ####");
        }

        public List<Category> FilterCategory(FiltersCategoryDto filterCategoryDto)
        {
            var FilterSql = "SELECT * FROM Products WHERE ";
            var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();

            if (filterCategoryDto.name != null)
            {
                FilterSql += "Name LIKE \"%" + filterCategoryDto.name + "%\" and ";
            }
            if (filterCategoryDto.status != null)
            {
                FilterSql += "Status = @status and ";
            }
            if (filterCategoryDto.name == null && filterCategoryDto.status == null)
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }
            if (filterCategoryDto.order != null)
            {
                if (filterCategoryDto.order != 1 && filterCategoryDto.order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if (filterCategoryDto.order == 1)
                {
                    FilterSql += " ORDER BY Name";
                }
                if (filterCategoryDto.order == 2)
                {
                    FilterSql += " ORDER BY Name DESC";
                }
            }

            var result = connection.Query<Category>(FilterSql, new
            {
                Name = filterCategoryDto.name,
                Status = filterCategoryDto.status,


            });
            if (filterCategoryDto.pageNumber > 0 && filterCategoryDto.itensPerPage > 0 && filterCategoryDto.itensPerPage <= 10)
            {
                var pages = result.Skip((filterCategoryDto.itensPerPage - 1) * filterCategoryDto.pageNumber)
                    .Take(filterCategoryDto.pageNumber).ToList();
                connection.Close();
                return pages;

            }

            var limit = result.Skip(0).Take(25).ToList();
            connection.Close();
            return limit;
        }

        public Category GetId(int Id)
        {
            logger.LogInformation($"#### Dao - Buscando Categoria por ID. ####");
            return _context.Categories.FirstOrDefault(category => category.Id == Id);
        }

        public Result EditCategory(Category editCategory)
        {
            editCategory.Modified = DateTime.Now;
            _context.Update(editCategory);
            _context.SaveChanges();
            logger.LogInformation($"#### Dao - Editando categoria. ####");
            return Result.Ok();
        }



        public SearchCategoriesDto ChangeStatus(int? Id)
        {

            var cat = _context.Categories.FirstOrDefault(category => category.Id == Id);
            var sub = _context.SubCategories.Where(sub => sub.CategoryId == Id).ToList();

            if (sub.Count == 0)
            {
                logger.LogWarning($"#### Erro: ID informado não existe.");
                return null;
            }
            if (cat.Status == false)
            {
                cat.Status = true;
                cat.Modified = DateTime.Now;
            }
            else if (cat.Status == true)
            {
                cat.Status = false;
                cat.Modified = DateTime.Now;
                foreach (SubCategory subcategory in sub)
                {
                    if (subcategory.Status == true)
                    {
                        subcategory.Status = false;
                        subcategory.Modified = DateTime.Now;
                    }
                }
            }

            _context.SaveChanges();
            logger.LogInformation($"#### Dao - Editando categoria. ####");
            return null;
        }

    }
}
