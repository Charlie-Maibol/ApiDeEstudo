using AutoMapper;
using Dapper;
using Eccomerce.Test;
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
    public class SubCategoryDao : ISubCategoryDao
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

        public void DeleteSubCategory(SubCategory subCategory)
        {
            _context.Remove(subCategory);
            _context.SaveChanges();
        }

        public SubCategory GetID(int id)
        {
            return _context.SubCategories.FirstOrDefault(p => p.Id == id);
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
            if (filterSubCategoryDto.name == null && filterSubCategoryDto.status == null)
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

        public SubCategory AddSubCategory(SubCategory subDto)
        {
            _context.SubCategories.Add(subDto);
            _context.SaveChanges();
            return subDto;

        }


        public SubCategory SearchSubId(int Id)
        {
           return _context.SubCategories.FirstOrDefault(sub => sub.Id == Id);
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _context.SubCategories.ToList();

        }

        public Result EditSubCategory(SubCategory subCategory)
        {
            subCategory.Modified = DateTime.Now;
            _context.Update(subCategory);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
