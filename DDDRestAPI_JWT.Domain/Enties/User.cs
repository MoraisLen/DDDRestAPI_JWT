using System.ComponentModel.DataAnnotations;

namespace DDDRestAPI_JWT.Domain.Enties
{
    public class User : EntieBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Phone, MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
    }
}