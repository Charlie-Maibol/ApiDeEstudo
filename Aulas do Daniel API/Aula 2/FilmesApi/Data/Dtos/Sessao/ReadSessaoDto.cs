using FilmesAPI.Models;
using System;
using System.Collections.Generic;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public Cinema Cinema { get; set; }
        public Filme Filme{ get; set; }
        public int Id { get; set; }

        public DateTime HorarioDeEncerramento { get; set; } 

        public DateTime HorarioDeInicio { get; set; }   
    }
}
