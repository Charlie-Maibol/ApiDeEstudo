using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Requests
{
    public class ResetPassword
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ReNewPassword { get; set; } 
    }
}
