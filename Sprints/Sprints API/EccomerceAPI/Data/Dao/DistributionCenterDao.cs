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
            center.ZipCode = street.ZipCode;
            center.Street = street.Street;
            center.Neighbourhood = street.Neighbourhood;
            center.UF = street.UF;

            _distributionContext.DistributionCenters.Add(center);
            _distributionContext.SaveChanges();

        }

        public List<DistributionCenter> FilterCenter(DistributionCenterFilterDto fIlterDto)
        {
            return null;
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
