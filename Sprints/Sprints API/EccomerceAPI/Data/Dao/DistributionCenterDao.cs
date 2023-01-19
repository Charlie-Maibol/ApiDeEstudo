using AutoMapper;
using EccomerceAPI.Data.Dtos.Products;
using EccomerceAPI.Data;
using EccomerceAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;

namespace EccomerceAPI.Data.productDao
{
    public class DistributionCenterDao
    {
        private AppDbContext _distributionContext;
        private IMapper _distributionMapper;
        private IConfiguration _distributionConfiguration;


        public DistributionCenterDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _distributionContext = context;
            _distributionMapper = mapper;
            _distributionConfiguration = configuration;
        }

        public void DeleteCenter(DistributionCenter center)
        {
            _distributionContext.Remove(center);
            _distributionContext.SaveChanges();
        }
        public void EditCenter(int id, DistributionCenter center)
        {

            _distributionContext.SaveChanges();
        }
        public DistributionCenter SearchCenterId(int id)
        {

            return _distributionContext.DistributionCenters.FirstOrDefault(c => c.Id == id);
        }
        public void CreateCenter(CreateDistributionCenterDto centerDto, DistributionCenter street)
        {
            var center = _distributionMapper.Map<DistributionCenter>(centerDto);
            center.Street = street.Street;
            center.Neighbourhood = street.Neighbourhood;
            center.UF = street.UF;
            center.City = street.City;


            _distributionContext.DistributionCenters.Add(center);
            _distributionContext.SaveChanges();

        }
        private static bool FilterIsNull(DistributionCenterFilterDto filterDto)
        {
            return filterDto.name == null && filterDto.addComplemente == null && filterDto.city == null && filterDto.UF == null
            && filterDto.zipCode == null && filterDto.street == null && filterDto.streetNumber == null && filterDto.status == null
            && filterDto.neighbourhood == null;
        }

        public List<DistributionCenter> FilterCenter(DistributionCenterFilterDto filterDto)
        {
            using var connection = new MySqlConnection(_distributionConfiguration.GetConnectionString("CategoryConnection"));
            connection.Open();
            var queryArgs = new DynamicParameters();
            var FilterSql = "SELECT d.id, d.name, d.addComplemente, d.status, d.city, d.uf, d.zipCode, d.street, d.streetNumber," +
                "d.neighbourhood as neighbourhood, " +
                "p.name as Product, p.distribuitonCenterId "  +
                "FROM DistributionCenters d " +
                "INNER JOIN Products p ON d.id = p.distribuitonCenterId " +
                "WHERE ";


            if(filterDto.id != null)
            {
                FilterSql += "d.id = @id and ";
                queryArgs.Add("Id", filterDto.id);
            }
            if (filterDto.name != null)
            {
                FilterSql += "d.name LIKE CONCAT('%',@name,'%') and ";
                queryArgs.Add("Name", filterDto.name);
            }
            if (filterDto.addComplemente != null)
            {
                FilterSql += "d.addComplemente LIKE CONCAT('%',@addComplemente,'%') and ";
                queryArgs.Add("AddComplemente", filterDto.addComplemente);
            }
            if (filterDto.status != null)
            {

                FilterSql += "d.status = @status and ";
                queryArgs.Add("Status", filterDto.status);
            }
            if (filterDto.city != null)
            {
                FilterSql += "d.city LIKE CONCAT('%',@city,'%') and ";
                queryArgs.Add("City", filterDto.city);
            }
            if (filterDto.UF != null)
            {              
                FilterSql += "d.uf LIKE CONCAT('%',@uf,'%') and ";
                queryArgs.Add("UF", filterDto.UF);
            }
            if (filterDto.zipCode != null)
            {
                FilterSql += "d.zipCode LIKE CONCAT('%',@zipCode,'%') and ";
                queryArgs.Add("ZipCode", filterDto.zipCode);
            }
            if (filterDto.street != null)
            {
                FilterSql += "d.street LIKE CONCAT('%',@street,'%') and ";
                queryArgs.Add("Street", filterDto.street);
            }
            if (filterDto.streetNumber != null)
            {
                
                FilterSql += "d.streetNumber = @streetNumber and ";
                queryArgs.Add("StreetNumber", filterDto.streetNumber);
            }
            if (filterDto.neighbourhood != null)
            {
                FilterSql += "d.neighbourhood LIKE CONCAT('%',@neighbourhood,'%') and ";
                queryArgs.Add("Neighbourhood", filterDto.neighbourhood);
            }
            if (FilterIsNull(filterDto))
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }
            if (filterDto.orderName != null)
            {
                
                if (filterDto.orderName == "product")

                {   if( filterDto.order == "asc")
                    {
                        FilterSql += " ORDER BY p.name";
                    }
                    else
                    {
                        FilterSql += "ORDER BY d.name";
                    }
                    
                }
                else
                {
                    if (filterDto.order == "desc")
                    {
                        FilterSql += " ORDER BY d.name DESC";
                    }
                    else
                    {
                        FilterSql += "ORDER BY p.name DESC";
                    }
                   
                }
            }

            var result = connection.Query<DistributionCenter, Category, DistributionCenter>
               (FilterSql, (center, product) => {
                   center.Id = product.Id;
                   return center;
               }, queryArgs, splitOn: "distribuitonCenterId")
               .Skip((filterDto.itensPerPage - 1) * filterDto.pageNumber)
               .Take(filterDto.pageNumber).ToList();

            connection.Close(); 
            return result;

        }


        public List<DistributionCenter> NullCenter(int? Id)
        {
            List<DistributionCenter> centers;
            if (Id == null)
            {
                centers = _distributionContext.DistributionCenters.ToList();
            }
            else
            {
                centers = _distributionContext.DistributionCenters.Where(c => c.Id == Id).ToList();


            }

            return centers;
        }


    }
}
