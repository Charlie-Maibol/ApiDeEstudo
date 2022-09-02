using AutoMapper;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dtos.Categories.DC;
using EccomerceAPI.Data.Dtos.DC;
using EccomerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceAPI.Controllers
{
    public class DcController
    {
        [ApiController]
        [Route("{controller}")]
        public class SubCategoryController : ControllerBase
        {

            private AppDbContext _context;
            private IMapper _mapper;


            public SubCategoryController(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            [HttpPost]
            public IActionResult AddSubCategory(CreateDcDto DcDto)
            {

                Dc dc = _mapper.Map<Dc>(DcDto);
                _context.Dcs.Add(dc);
                _context.SaveChanges();
                return CreatedAtAction(nameof(searchSubId), new { dc.Id }, dc);
            }

            [HttpGet]
            public IEnumerable<Dc> ShowDcs()
            {
                return _context.Dcs;
            }


            [HttpGet("{Id}")]
            public IActionResult searchSubId(int id)
            {
                Dc dc =  _context.Dcs.FirstOrDefault(dc => dc.Id == id);
                if (dc != null)
                {

                    SearchDcsDto subCategory = _mapper.Map<SearchDcsDto>(dc);
                    return Ok(dc);
                }

                return NotFound();
            }

            [HttpGet("Filter")]
            public IActionResult Search([FromQuery] string name = null, [FromQuery] int? ord = null,
                        [FromQuery] bool? status = null, [FromQuery] int pageNumber = 0, [FromQuery] int itensPerPage = 0)
            {

                return NotFound();
            }


            [HttpPut("{ID}")]
            public IActionResult EditDC(int Id, [FromBody] EditDcDto DcDto)
            {
                Dc dc = _context.Dcs.FirstOrDefault(dc => dc.Id == Id);
                
                if (dc == null)
                {

                    return NotFound();
                }
                
                _mapper.Map(DcDto, dc);
                _context.SaveChanges();
                return NoContent();

            }
            [HttpDelete("{ID}")]
            public IActionResult DeletSubCategory(int ID)
            {
                Dc dc = _context.Dcs.FirstOrDefault(dc => dc.Id == ID);
                if (dc == null)
                {

                    return NotFound();
                }
                _context.Remove(dc);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
