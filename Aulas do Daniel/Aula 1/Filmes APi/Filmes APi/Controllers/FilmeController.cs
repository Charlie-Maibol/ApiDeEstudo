using Filmes_APi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Filmes_APi.Controllers
{
    [ApiController]
    [Route("controller")]                           

    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        public void adicionarFilme(Filme filme)
        {
            filmes.Add(filme);
        }
    }
}
