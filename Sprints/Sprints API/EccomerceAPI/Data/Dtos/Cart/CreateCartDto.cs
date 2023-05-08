using EccomerceAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace EccomerceAPI.Data.Dtos.Cart
{
    public class CreateCartDto
    {
        public string ZipCode { get; set; }
        public int StreetNumber { get; set; }
        public string AddComplemente { get; set; }


    }
}
