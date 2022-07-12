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

        private static List<Filme> filmes = new List<Filme>();

        private static int ID = 1;

        [HttpPost]
        public IActionResult adicionarFilme([FromBody]Filme filme)
        {
            filme.ID = ID++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperarFilmesPorID), new { ID = filme.ID }, filme);
            
        }
        [HttpGet]
        public IActionResult Recuperar()
        {
            return Ok(filmes);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorID(int ID)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.ID == ID);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
