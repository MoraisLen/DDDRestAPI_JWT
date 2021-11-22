using System.ComponentModel.DataAnnotations;

namespace DDDRestAPI_JWT.Domain.DTOs
{
    public class DTOUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name must be a maximum of 50 characters.")]
        public string Name { get; set; }

        [Required]
        [Phone(ErrorMessage = "Phone is invalid.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email Address is invalid.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Password must be a maximum of 20 characters.")]
        public string Password { get; set; }
    }
}