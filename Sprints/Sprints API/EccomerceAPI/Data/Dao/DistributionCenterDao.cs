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
        private AppDbContext _disctributionContext;
        private IMapper _disctributionMapper;
        private IConfiguration _disctributionConfiguration;

        public DistributionCenterDao(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _disctributionContext = context;
            _disctributionMapper = mapper;
            _disctributionConfiguration = configuration;
        }
        public SearchDistributionCentersDto AddCenter(CreateDistributionCenterDto centerDto)
        {
            var center = _disctributionMapper.Map<DistributionCenter>(centerDto);
            _disctributionContext.DistributionCenters.Add(center);
            _disctributionContext.SaveChanges();
            return _disctributionMapper.Map<SearchDistributionCentersDto>(center);
        }
        public void DeleteCenter(DistributionCenter center)
        {
            _disctributionContext.Remove(center);
            _disctributionContext.SaveChanges();
        }
        public void EditCenter(int id, DistributionCenter center)
        {

            _disctributionContext.SaveChanges();
        }
        public DistributionCenter SearchCenterId(int id)
        {

            return _disctributionContext.DistributionCenters.FirstOrDefault(p => p.Id == id);
        }
        public List<DistributionCenter> NullCenter(int? Id)
        {
            List<DistributionCenter> centers;
            if (Id == null)
            {
                centers = _disctributionContext.DistributionCenters.ToList();
            }
            else
            {
                centers = _disctributionContext.DistributionCenters.Where(p => p.Id == Id).ToList();


            }

            return centers;
        }

        public object FilterCenter(string name, string center, bool? status, double? weight, double? height, double? lengths, double? widths, double? price, int? amountOfProducts, int? order, int pageNumber, int itensPerPage)
        {
            throw new NotImplementedException();
        }
    }
}
