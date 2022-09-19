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
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;

namespace EccomerceAPI.Services
{
    public class DistributionCenterServices
    {
        private AppDbContext _distributionContext;
        private DistributionCenterDao _distributionDao;
        private IMapper _distributionMapper;
        private ProductsServices _productService;

        public DistributionCenterServices(AppDbContext context, IMapper mapper, DistributionCenterDao dao, IConfiguration configuration,
            ProductsServices prodService)
        {
            _distributionContext = context;
            _distributionCenterMapper = mapper;
            _distributionCenterDao = dao;
            _productService = prodService;


        }
        private AppDbContext _distributionCenterContext;
        private DistributionCenterDao _distributionCenterDao;
        private IMapper _distributionCenterMapper;

        public SearchDistributionCentersDto AddCenter(CreateDistributionCenterDto centerDto)
        {

            DistributionCenter center = _distributionCenterMapper.Map<DistributionCenter>(centerDto);
            List<Product> prod = _productService.GetProductsCenterID(Id);
            SubCategory sub = _distributionContext.SubCategories.FirstOrDefault(sub => sub.Id == sub.CategoryId);
            if (sub.Status == true && prod.Status == true)
            {


                return _distributionCenterDao.AddCenter(centerDto);
            }
            else
            {
               throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            

        }
        public List<SearchDistributionCentersDto> SearchDistributionCenterId(int? Id)
        {
            List<DistributionCenter> center;

            center = _distributionCenterDao.NullCenter(Id);
            if (center != null)
            {
                List<SearchDistributionCentersDto> centerDto = _distributionCenterMapper.Map<List<SearchDistributionCentersDto>>(center);
                return centerDto;
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
            var center = _distributionCenterDao.SearchCenterId(id);
            if (center == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _distributionCenterDao.DeleteCenter(center);
            return Result.Ok();
        }


    }
}
