using System;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.DTOs
{
    public class SearchUserDto
    {
        
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
  
        [Compare("PassWord")]
        public string RePassWord { get; set; }
        public DateTime? BirthDay { get; set; }
       
        public string CPF { get; set; }
        public bool Status { get; set; } = true;
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
       
        public string AddComplemente { get; set; }
    }
}
