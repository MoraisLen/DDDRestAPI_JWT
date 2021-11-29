using System.ComponentModel.DataAnnotations;

namespace DDDRestAPI_JWT.Domain.DTOs
{
    public class DTOClientAPI
    {
        [Required]
        [StringLength(20, ErrorMessage = "NameId must be a maximum of 20 characters.")]
        public string NameId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Secret must be a maximum of 20 characters.")]
        public string Secret { get; set; }

        [StringLength(10)]
        public string? Role { get; set; }
    }
}