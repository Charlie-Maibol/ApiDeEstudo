using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EccomerceAPI.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;
       
        public virtual List<SubCategory> SubCategories { get; set; }
        
    }
}
