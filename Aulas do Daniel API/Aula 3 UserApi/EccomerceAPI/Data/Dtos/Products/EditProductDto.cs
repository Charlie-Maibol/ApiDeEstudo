﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Data.Dtos.Products
{
    public class EditProductDto
    {

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Modified { get; set; } = DateTime.Now;
        public int distribuitonCenterId { get; set; }

    }
}
