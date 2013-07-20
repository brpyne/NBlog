using System.ComponentModel.DataAnnotations;

namespace Fullback.WebHost.Models
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsValid { get; set; }
    }
}