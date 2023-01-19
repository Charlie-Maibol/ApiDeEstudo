﻿using AutoMapper;
using Dapper;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.Categories;
using EccomerceAPI.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace EccomerceAPI.Data.Dao
{
    public class CategoryDao
    {


        private AppDbContext _context;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public CategoryDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Result ListCategories(int pageNumber, int itensPerPage, int? Id)
        {
            List<Category> categories;

            if (Id == null)
            {
                categories = _context.Categories.ToList();
            }

            else
            {
                categories = _context.Categories.Where(cat => cat.Id == Id)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage).ToList();
                List<SearchCategoriesDto> category = _mapper.Map<List<SearchCategoriesDto>>(categories);

            }
            if (categories != null)
            {
                List<SearchCategoriesDto> category = _mapper.Map<List<SearchCategoriesDto>>(categories);
                return Result.Ok();
            }
            return null;
        }

        public List<Category> NullCategories(int? Id)
        {
            List<Category> category;
            if (Id == null)
            {
                category = _context.Categories.ToList();
            }
            else
            {
                category = _context.Categories.Where(p => p.Id == Id).ToList();


            }

            return category;
        }

        public void DeleteCategory(int iD)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == iD);

            _context.Remove(category);
            _context.SaveChanges();
        }
        private static bool Null(FiltersCategoryDto filterCategoryDto)
        {
            return filterCategoryDto.name == null && filterCategoryDto.status == null;
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
            if (Null(filterCategoryDto))
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
    }
}
