using System.ComponentModel.DataAnnotations;

namespace DDDRestAPI_JWT.Domain.DTOs
{
    public class DTOClientAPI
    {
        [Required]
        public string NameId { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}