using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace EccomerceAPI.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int Id { get; internal set; }

        public virtual List<CartWithProduct> CartWithProducts { get; set; }

        public string City { get; set; }

        public string UF { get; set; }

        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string Neighbourhood { get; set; }

        public int ProductId { get; set; }
        public int TotalAmount { get; set; }
        public string AddComplemente { get; set; }
        public double Totalprice { get; set; }

    }
}
