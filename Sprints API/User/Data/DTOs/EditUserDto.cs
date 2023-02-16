using System;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.DTOs
{
    public class EditUserDto
    {
    
        public string UserName { get; set; }
      
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string PassWord { get; set; }
 
        [Compare("PassWord")]
        public string RePassWord { get; set; }
        public DateTime? BirthDay { get; set; }
        [Required]
        public string CPF { get; set; }
        public bool? Status { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string AddComplemente { get; set; }
    }
}
