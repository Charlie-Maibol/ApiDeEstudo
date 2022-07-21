using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Data.Dtos
{
    public class CreateSubCategoryDto
    {

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public DateTime created { get; set; } = DateTime.Now;

        public DateTime Consult { get; set; } = DateTime.Now;
    }
}
