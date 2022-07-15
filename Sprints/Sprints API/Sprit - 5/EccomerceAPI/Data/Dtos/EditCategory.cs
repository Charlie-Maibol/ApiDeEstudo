using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Data.Dtos
{
    public class EditCategoryDto
    {

        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Modified { get; set; } = DateTime.Now;

        public DateTime Consult { get; set; } = DateTime.Now;
        
    }
}
