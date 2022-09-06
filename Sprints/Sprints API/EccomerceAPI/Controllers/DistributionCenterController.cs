using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Models;
using EccomerceAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceAPI.Controllers
{


    [ApiController]
    [Route("{controller}")]
    public class DistributionCenterController : ControllerBase
    {


        private DistributionCenterDao _distributionDao;
        private IMapper _distributionMapper;
        private DistributionCenterServices _distributionService;

        public DistributionCenterController(DistributionCenterServices service, DistributionCenterDao centerDao)
        {
            _distributionService = service;
            _distributionDao = centerDao;
        }

        [HttpPost]
        public IActionResult AddCenter([FromBody] CreateDistributionCenterDto centerDto)
        {
            SearchDistributionCentersDto searchCenter = _distributionService.AddCenter(centerDto);
            return CreatedAtAction(nameof(SearchProdId), new { id = searchCenter.Id }, searchCenter);
        }
        [HttpGet("{ID}")]
        public IActionResult SearchProdId(int? Id)
        {
            List<SearchDistributionCentersDto> distributionCenterDto = _distributionService.SearchDistributionCenterId(Id);
            if (distributionCenterDto != null)
            {
                return Ok(distributionCenterDto);

            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult FilterCenter([FromQuery] string name, [FromQuery] string center, [FromQuery] bool? status, [FromQuery] double? weight,
            [FromQuery] double? height, [FromQuery] double? lengths, [FromQuery] double? widths,
            [FromQuery] double? price, [FromQuery] int? amountOfProducts, [FromQuery] int? order,
            [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
        {


            return Ok(_distributionDao.FilterCenter(name, center, status, weight, height, lengths, widths, price, amountOfProducts, order, pageNumber, itensPerPage));


        }
        [HttpPut("{Id}")]
        public IActionResult EditCenter(int Id, [FromBody] EditDistributionCenterDto Center)
        {
            Result result = _distributionService.EditCenter(Id, Center);
            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{Id}")]

        public IActionResult DeletCenter(int Id)
        {
            Result result = _distributionService.DeletCenter(Id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
    }

}
