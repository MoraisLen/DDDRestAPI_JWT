using System.ComponentModel.DataAnnotations;

namespace DDDRestAPI_JWT.Domain.DTOs
{
    public class DTOClientAPI
    {
        [Required]
        [MaxLength(20)]
        public string NameId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Secret { get; set; }
    }
}