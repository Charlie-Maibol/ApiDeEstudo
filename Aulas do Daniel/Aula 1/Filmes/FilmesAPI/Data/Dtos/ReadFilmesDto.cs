using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmesDto
    {
        [Key]
        [Required]
        public int ID { get; internal set; }

        [Required(ErrorMessage = "O campo titulo é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatorio")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O Genero só pode conter até 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "O campo de duração execede o tempo limite")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
