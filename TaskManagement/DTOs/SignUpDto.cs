using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TaskManagement.DTOs
{
    public class SignUpDto
    {
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [Required, Compare("ConfirmedPassword")]
        public required string Password { get; set; }

        [Required]
        public  required string ConfirmedPassword { get; set; }
    }
}
