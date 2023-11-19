using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required to login.")]
        [EmailAddress(ErrorMessage = "Invalid format email.")]
        [StringLength(100, ErrorMessage = "The email must have a maximum of {1} characters.")]
        public string Email { get; set; }
    }
}
