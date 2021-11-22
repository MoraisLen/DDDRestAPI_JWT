using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDRestAPI_JWT.Domain.Enties
{
    [Table("ClientAPI")]
    public class ClientAPI : EntieBase
    {
        [Required]
        [MaxLength(20)]
        public string NameId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Secret { get; set; }

        [Required]
        [MaxLength(10)]
        public string Role { get; set; }
    }
}