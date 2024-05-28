using System.ComponentModel.DataAnnotations;

namespace LocalStorageSample.Models
{
    public class LoginForm
    {
        [Required]
        public string? Nom { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
