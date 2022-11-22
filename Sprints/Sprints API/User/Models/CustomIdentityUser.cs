using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        
        public DateTime? BirthDay { get; set; }
        [Required]
        public string CPF { get; set; }
        public bool Status { get; set; } = true;
        public string ZipCode {get; set;}
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }

        public DateTime CriatonDate { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public string AddComplemente { get; set; }

    }
}
