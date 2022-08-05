using EccomerceAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EccomerceAPI.Data.Dtos.SubCategories
{
    public class SearchSubCategoriesDto
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public DateTime created { get; set; }

        public DateTime Consult { get; set; } = DateTime.Now;

        public Category Category { get; set; }
    }
}
