using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        [Required]
        public string CPF { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; } = true;
        public DateTime SignInDate { get; set; } = DateTime.Now;
        public string ZipCode {get; set;}
        public string Street { get; set; }
        public string StretNumber { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }

        public DateTime CriatonDate { get; set; }
        public DateTime EditDate { get; set; }
        public string AddComplemente { get; set; }

    }
}
