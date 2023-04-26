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

        public virtual Cart Carts { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double IndividualPrice { get; set; } 
        public int AmountOfProducts { get; set; }   

    }
}
