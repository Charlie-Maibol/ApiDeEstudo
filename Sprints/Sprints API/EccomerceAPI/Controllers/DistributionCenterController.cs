  using AutoMapper;
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
using System.Threading.Tasks;

namespace EccomerceAPI.Controllers
{


    [ApiController]
    [Route("{controller}")]
    public class DistributionCenterController : ControllerBase
    {


        private DistributionCenterDao _distributionDao;
        private DistributionCenterServices _distributionService;

        public DistributionCenterController(DistributionCenterServices service, DistributionCenterDao centerDao)
        {
            _distributionService = service;
            _distributionDao = centerDao;
        }

        [HttpPost]
        public async Task <IActionResult> AddCenter([FromBody] CreateDistributionCenterDto centerDto)
        {
            SearchDistributionCentersDto searchDistribution = await _distributionService.CreateCenter(centerDto);            
            return CreatedAtAction(nameof(SearchCenterId), new { id = centerDto.Id }, centerDto);
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
        [HttpGet("filter")]
        public IEnumerable<DistributionCenter> FilterCenter([FromBody] DistributionCenterFilterDto fIlterDto)
        {
            return _distributionDao.FilterCenter(fIlterDto);
            


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
