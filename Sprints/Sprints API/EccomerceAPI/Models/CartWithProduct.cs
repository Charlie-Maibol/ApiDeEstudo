using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace EccomerceAPI.Models
{
    public class CartWithProduct
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        public bool Status { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        public string ZipCode { get; set; }
        public double Totalprice { get; set; }
        public virtual Cart Carts { get; set; }
        public virtual Product Products { get; set; }

        public int ProductId { get; set; }

        public int CartId { get; set; }

    }
}
