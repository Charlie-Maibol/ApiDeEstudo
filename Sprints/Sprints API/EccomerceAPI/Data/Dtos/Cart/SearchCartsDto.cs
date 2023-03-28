using EccomerceAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace EccomerceAPI.Data.Dtos.Cart
{
    public class SearchCartsDto
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        public bool Status { get; set; }

        public virtual List<Product> Products { get; set; }

        public string ZipCode { get; set; }

        public int Totalprice { get; set; }
    }
}
