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
using System.Threading.Tasks;
using Newtonsoft.Json;
using EccomerceAPI.Data.Dtos.DistribuitonCenters;
using EccomerceAPI.Data.Dtos.Products;

namespace EccomerceAPI.Services
{
    public class DistributionCenterServices
    {
        private readonly AppDbContext _distributionContext;
        private readonly DistributionCenterDao _distributionDao;
        private readonly IMapper _distributionMapper;
        private AppDbContext _productContext;

        public DistributionCenterServices(AppDbContext context, IMapper mapper, DistributionCenterDao dao, IConfiguration configuration,
            AppDbContext prodContext)
        {
            _distributionContext = context;
            _distributionMapper = mapper;
            _distributionDao = dao;
            _productContext = prodContext;


        }
      

        public async Task <SearchDistributionCentersDto>CreateCenter(CreateDistributionCenterDto centerDto)
        {
            var street = await GetAdress(centerDto.ZipCode);
            if (street.Street == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {

                _distributionDao.CreateCenter(centerDto, street);
                
            }
            return null;

        }

        public async Task<DistributionCenter>GetAdress(string cep)
        {
            HttpClient client = new HttpClient();
            var requisition = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var json = await requisition.Content.ReadAsStringAsync();
            DistributionCenter distributionCenter = new DistributionCenter();
            var viacep = JsonConvert.DeserializeObject<ViaCepDto>(json);
            ViaCep(distributionCenter, viacep);
            return distributionCenter;

        }

        private bool UniqueAddress(DistributionCenter center)
        {
            DistributionCenterFilterDto filter = new();
            var centerList = _distributionDao.FilterCenter(filter);
            string address = center.Street;
            address += center.StreetNumber;
            address += center.AddComplemente;

            foreach (var a in centerList)
            {
                string addressComplet = a.Street;
                addressComplet += a.StreetNumber;
                addressComplet += a.AddComplemente;
                if( address == addressComplet)
                {
                    return false;
                }
                
            }

            return true;
        }

        private static void ViaCep(DistributionCenter distributionCenter, ViaCepDto viacep)
        {
            distributionCenter.ZipCode = viacep.cep;
            distributionCenter.Street = viacep.logradouro;
            distributionCenter.UF = viacep.uf;
            distributionCenter.Neighbourhood = viacep.bairro;
            distributionCenter.City = viacep.localidade;
        }

        public List<SearchDistributionCentersDto> SearchDistributionCenterId(int? Id)
        {
            List<DistributionCenter> center;

            center = _distributionDao.NullCenter(Id);
            if (center != null)
            {
                List<SearchDistributionCentersDto> centerDto = _distributionMapper.Map<List<SearchDistributionCentersDto>>(center);
                return centerDto;
            }
            return null;

        }


        public Result EditCenter(int id, EditDistributionCenterDto centerDto)
        {
            List<Category> prod = _productContext.Categories.Where(prod => prod.Id == id && prod.Status == true).ToList();
            var center = _distributionDao.SearchCenterId(id);
            if (center == null) 
            {

                return Result.Fail("Produto não encontrado");
            }
            if(prod.Count > 0 && center.Status != true)
            {
                return Result.Fail("Ainda existem produtos ativos");
            }
            _distributionMapper.Map(centerDto, center);
            _distributionDao.EditCenter(id, center);
            return Result.Ok();
        }
        public Result DeletCenter(int id)
        {
            var center = _distributionDao.SearchCenterId(id);
            if (center == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _distributionDao.DeleteCenter(center);
            return Result.Ok();
        }


    }
}
