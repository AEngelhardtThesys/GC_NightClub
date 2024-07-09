using GC_NightClub.WebAPI.Domain.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GC_NightClub.WebAPI.Domain.Interfaces;

namespace GC_NightClub.WebAPI.Domain
{
    public class IdentityCard : IEntity<Guid>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("FirstName")]
        [Required]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Required]
        public string LastName { get; set; }

        [Column("BirthDate")]
        [Required]
        public DateTime BirthDate { get; set; }

        // Assuming the format in the instructions has a typo, and using the actual format for belgian national registry numbers. For instance : 03.02.01-123.45
        [Column("NationalRegistryNumber")]
        [Required]
        public string NationalRegistryNumber { get; set; }

        // Assuming the card number also requires a simple format validation
        [Column("CardNumber")]
        [Required]
        public string CardNumber { get; set; }

        [Column("ValidDate")]
        [Required]
        public DateTime ValidDate { get; set; }

        [Column("ExpirationDate")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<MemberCard> MemberCards { get; set; }
    }
}
