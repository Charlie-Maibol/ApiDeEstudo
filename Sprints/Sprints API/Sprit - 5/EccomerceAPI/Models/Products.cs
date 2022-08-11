using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Price { get; set; }
        public double Lengths { get; set; }
        public double Widths { get; set; }
        public int AmountOfProducts { get; set; }
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        public string DistributionCenter { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
