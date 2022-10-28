using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]       
        public string PassWord { get; set; }
        [Required]
        [Compare("PassWord")]
        public string RePassWord { get; set; }

    }
}
