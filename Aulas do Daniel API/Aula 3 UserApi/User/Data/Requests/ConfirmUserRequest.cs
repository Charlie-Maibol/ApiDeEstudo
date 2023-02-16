using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Requests
{
    public class ConfirmUserRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ActivationCode { get; set; }  
    }
}
