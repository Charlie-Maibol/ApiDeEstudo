using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Models
{
    public class Dc
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; }

        public string City { get; set; }

        public string UF { get; set; }

        public int ZipCode {get ; set;}

        public string Street { get; set; }
        public int StreetCode { get; set; }
        public string Block { get; set; }
        public string Avenue { get; set; }  


    }
}
