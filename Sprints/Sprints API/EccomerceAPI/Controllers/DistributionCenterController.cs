﻿using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Data.Dtos.Products;
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
            return CreatedAtAction(nameof(SearchCenterId), new { id = searchCenter.Id }, searchCenter);
        }
        [HttpGet("{ID}")]
        public IActionResult SearchCenterId(int? Id)
        {
            List<SearchDistributionCentersDto> distributionCenterDto = _distributionService.SearchDistributionCenterId(Id);
            if (distributionCenterDto != null)
            {
                return Ok(distributionCenterDto);

            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult FilterCenter([FromQuery]DistributionCenterFilterDto fIlterDto)
        {

            _distributionDao.FilterCenter(fIlterDto);
            return Ok(fIlterDto);


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
