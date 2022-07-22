using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Models
{
    public class SubCategory
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public DateTime created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
