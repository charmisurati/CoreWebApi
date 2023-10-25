using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class SignUpModel
    {

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }
        
        [Required]
        public string? Password { get; set; }

    }

}
