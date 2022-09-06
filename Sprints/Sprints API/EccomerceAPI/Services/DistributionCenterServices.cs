using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using FluentResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EccomerceAPI.Services
{
    public class DistributionCenterServices
    {
        private AppDbContext _distributionContext;
        private DistributionCenterDao _distributionDao;
        private IMapper _distributionMapper;

        public DistributionCenterServices(AppDbContext context, IMapper mapper, DistributionCenterDao dao, IConfiguration configuration)
        {
            _distributionContext = context;
            _distributionCenterMapper = mapper;
            _distributionCenterDao = dao;



        }
        private AppDbContext _distributionCenterContext;
        private DistributionCenterDao _distributionCenterDao;
        private IMapper _distributionCenterMapper;

        public SearchDistributionCentersDto AddCenter(CreateDistributionCenterDto distributionCenterDto)
        {

            return null;

        }
        public List<SearchDistributionCentersDto> SearchDistributionCenterId(int? Id)
        {
            List<DistributionCenter> products;

            products = _distributionCenterDao.NullCenter(Id);
            if (products != null)
            {
                List<SearchDistributionCentersDto> productDto = _distributionCenterMapper.Map<List<SearchDistributionCentersDto>>(products);
                return productDto;
            }
            return null;

        }


        public Result EditCenter(int id, EditDistributionCenterDto centerDto)
        {
            var center = _distributionCenterDao.SearchCenterId(id);
            if (center == null)
            {

                return Result.Fail("Produto não encontrado");
            }
            _distributionCenterMapper.Map(centerDto, center);
            _distributionCenterDao.EditCenter(id, center);
            return Result.Ok();
        }
        public Result DeletCenter(int id)
        {
            var product = _distributionCenterDao.SearchCenterId(id);
            if (product == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _distributionCenterDao.DeleteCenter(center);
            return Result.Ok();
        }


    }
}
