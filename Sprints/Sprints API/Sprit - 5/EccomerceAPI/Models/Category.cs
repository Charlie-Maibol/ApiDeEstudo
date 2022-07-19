﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EccomerceAPI.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int ID { get; internal set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, ErrorMessage = "Você excedeu o número da caracteres permitidos!")]
        [RegularExpression (@"^[a-zA-Z' '-'\s]{1,40}$")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public DateTime created { get; set; } = DateTime.Now;

        public DateTime Consult { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

    }
}