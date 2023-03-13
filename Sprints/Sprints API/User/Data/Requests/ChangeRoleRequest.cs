using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Requests
{
    public class ChangeRoleRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
