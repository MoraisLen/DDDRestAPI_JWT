using System.ComponentModel.DataAnnotations;

namespace DDDRestAPI_JWT.Domain.Enties
{
    public abstract class EntieBase
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}