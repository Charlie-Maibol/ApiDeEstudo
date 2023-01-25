﻿using AutoMapper;
using Dapper;
using EccomerceAPI.Data.Dtos;
using EccomerceAPI.Data.Dtos.SubCategories;
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
    public class SubCategoryDao
    {

        private AppDbContext _context;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public SubCategoryDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        internal void DeleteSubCategory(object subCategory)
        {
            _context.Remove(subCategory);
            _context.SaveChanges();
        }

        public SubCategory SearchId(int id)
        {
            return _context.SubCategories.FirstOrDefault(p => p.Id == id);
        }

        private bool Null(SubCategoryFilterDto filterSubCategoryDto)
        {
            throw new NotImplementedException();
        }
        public List<SubCategory> FilterProduct(SubCategoryFilterDto filterSubCategoryDto)
        {
            var FilterSql = "SELECT * FROM Products WHERE ";
            var connection = new MySqlConnection(_configuration.GetConnectionString("CategoryConnection"));
            connection.Open();

            if (filterSubCategoryDto.name != null)
            {
                FilterSql += "Name LIKE \"%" + filterSubCategoryDto.name + "%\" and ";
            }
            if (filterSubCategoryDto.CategoryId != null)
            {
                FilterSql += "CategoryId = @categoryId and ";
            }
            if (filterSubCategoryDto.status != null)
            {
                FilterSql += "Status = @status and ";
            }
            if (Null(filterSubCategoryDto))
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }
            if (filterSubCategoryDto.order != null)
            {
                if (filterSubCategoryDto.order != 1 && filterSubCategoryDto.order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if (filterSubCategoryDto.order == 1)
                {
                    FilterSql += " ORDER BY Name";
                }
                if (filterSubCategoryDto.order == 2)
                {
                    FilterSql += " ORDER BY Name DESC";
                }
            }

            var result = connection.Query<SubCategory>(FilterSql, new
            {
                Name = filterSubCategoryDto.name,
                Status = filterSubCategoryDto.status,
                DistributionCenter = filterSubCategoryDto.CategoryId,
                


            });
            if (filterSubCategoryDto.pageNumber > 0 && filterSubCategoryDto.itensPerPage > 0 && filterSubCategoryDto.itensPerPage <= 10)
            {
                var pages = result.Skip((filterSubCategoryDto.itensPerPage - 1) * filterSubCategoryDto.pageNumber)
                    .Take(filterSubCategoryDto.pageNumber).ToList();
                connection.Close();
                return pages;

            }

            var limit = result.Skip(0).Take(25).ToList();
            connection.Close();
            return limit;

        }


    }
}
