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
        private static bool FilterIsNull(DistributionCenterFilterDto fIlterDto)
        {
            return fIlterDto.name == null && fIlterDto.addComplemente == null && fIlterDto.city == null && fIlterDto.UF == null
            && fIlterDto.zipCode == null && fIlterDto.street == null && fIlterDto.streetNumber == null && fIlterDto.status == null
            && fIlterDto.neighbourhood == null;
        }

        public List<DistributionCenter> FilterCenter(DistributionCenterFilterDto fIlterDto)
        {
            var connection = new MySqlConnection(_distributionConfiguration.GetConnectionString("CategoryConnection"));
            connection.Open();
            var FilterSql = "SELECT * FROM DistributionCenters WHERE ";



            if (fIlterDto.name != null)
            {
                FilterSql += "Name LIKE \"%" + fIlterDto.name + "%\" and ";
            }
            if (fIlterDto.addComplemente != null)
            {
                FilterSql += "AddComplemente LIKE \"%" + fIlterDto.addComplemente + "%\" and ";
            }
            if (fIlterDto.status != null)
            {
                FilterSql += "Status = @status and ";
            }
            if (fIlterDto.city != null)
            {
                FilterSql += "City LIKE \"%" + fIlterDto.city + "%\" and ";
            }
            if (fIlterDto.UF != null)
            {
                FilterSql += "UF LIKE \"%" + fIlterDto.UF + "%\" and ";
            }
            if (fIlterDto.zipCode != null)
            {
                FilterSql += "ZipCode LIKE \"%" + fIlterDto.zipCode + "%\" and ";
            }
            if (fIlterDto.street != null)
            {
                FilterSql += "Street LIKE \"%" + fIlterDto.street + "%\" and ";
            }
            if (fIlterDto.streetNumber != null)
            {
                FilterSql += "StreetNumber = @streetNumber and ";
            }
            if (fIlterDto.neighbourhood != null)
            {
                FilterSql += "Neighbourhood LIKE \"%" + fIlterDto.neighbourhood + "%\" and ";
            }
            if (FilterIsNull(fIlterDto))
            {
                var wherePosition = FilterSql.LastIndexOf("WHERE");
                FilterSql = FilterSql.Remove(wherePosition);
            }
            else
            {
                var andPosition = FilterSql.LastIndexOf("and");
                FilterSql = FilterSql.Remove(andPosition);
            }
            if (fIlterDto.order != null)
            {
                if (fIlterDto.order != 1 && fIlterDto.order != 2)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                if (fIlterDto.order == 1)
                {
                    FilterSql += " ORDER BY Name";
                }
                if (fIlterDto.order == 2)
                {
                    FilterSql += " ORDER BY Name DESC";
                }
            }

            var result = connection.Query<DistributionCenter>(FilterSql, new
            {
                Name = fIlterDto.name,
                Status = fIlterDto.status,
                City = fIlterDto.city,
                UF = fIlterDto.UF,
                ZipCode = fIlterDto.zipCode,
                Street = fIlterDto.street,
                StreetNumber = fIlterDto.streetNumber,
                Neighbourhood = fIlterDto.neighbourhood,
                AddComplemente = fIlterDto.addComplemente,
                Product = fIlterDto.Product,
                SubCategory = fIlterDto.SubCategory,


            });
            if (fIlterDto.pageNumber > 0 && fIlterDto.itensPerPage > 0 && fIlterDto.itensPerPage <= 10)
            {
                var pages = result.Skip((fIlterDto.itensPerPage - 1) * fIlterDto.pageNumber)
                    .Take(fIlterDto.pageNumber).ToList();
                connection.Close();
                return pages;

            }

            var limit = result.Skip(0).Take(25).ToList();
            connection.Close();
            return limit;

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
