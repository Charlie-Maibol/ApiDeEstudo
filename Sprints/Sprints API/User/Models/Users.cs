using System;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Você excedeu o número máximo de caracteres")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Neighborhood { get; set; }
        public int StreetNumber { get; set; }
        public string AddComplemente { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CriationDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
