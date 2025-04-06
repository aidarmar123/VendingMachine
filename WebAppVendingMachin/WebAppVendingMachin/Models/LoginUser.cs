using System.ComponentModel.DataAnnotations;

namespace WebAppVendingMachin.Models
{
    public class LoginUser
    {
        [Required]
        [Length(3, 50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Length(8, 50)]
        [RegularExpression("^(?=.*[A-z])(?=.*[0-9])(?=.*[!@#$%^&*()?><:\"{}\\[\\]|~`]).+$")]
        public string Password { get; set; }
    }
}
