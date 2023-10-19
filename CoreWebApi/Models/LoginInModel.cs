using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class LoginInModel
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }

}
