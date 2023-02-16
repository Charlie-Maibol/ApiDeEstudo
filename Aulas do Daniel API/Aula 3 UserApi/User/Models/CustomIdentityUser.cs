using Microsoft.AspNetCore.Identity;
using System;

namespace UserAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; } = true;
        public DateTime SignInDate { get; set; } = DateTime.Now;    
    }
}
