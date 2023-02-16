using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult adicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmesPorID), new { ID = filme.ID }, filme);
        }
            
        [HttpGet]
        public IEnumerable<Filme> Recuperar()
        {
            return _context.Filmes;
        }
        [HttpGet("{ID}")]
        public IActionResult RecuperarFilmesPorID(int ID)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.ID == ID);
            if(filme != null)
            {
                ReadFilmesDto filmeDto = _mapper.Map<ReadFilmesDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();
        }
        [HttpPut("{ID}")]
        public IActionResult AtualizarFilme(int ID, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.ID == ID);
            if(filme == null)
            {
                
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();

            
        }
        [HttpDelete("{ID}")]
        public IActionResult DeletaFilme(int ID)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.ID == ID);
            if (filme == null)
            {
                
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
