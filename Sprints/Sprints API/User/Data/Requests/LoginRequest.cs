using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
