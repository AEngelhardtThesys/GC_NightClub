using GC_NightClub.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GC_NightClub.Domain.Attributes;

namespace GC_NightClub.Domain
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
        [ValidateWithRegex(@"^\d{2}.\d{2}.\d{2}[-]\d{3}.\d{2}$", nameof(NationalRegistryNumber), "##.##.##-###.##")]
        [Required]
        public string NationalRegistryNumber { get; set; }

        [Column("ValidDate")]
        [PastDate("Validity date")]
        [Required]
        public DateTime ValidDate { get; set; }

        [Column("ExpirationDate")]
        [FutureDate("Expiration date")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        // Assuming the card number also requires a simple format validation
        [Column("CardNumber")]
        [ValidateWithRegex(@"^\d{3}[-]\d{7}[-]\d{2}$", nameof(CardNumber), "###-#######-##")]
        [Required]
        public string CardNumber { get; set; }

        [JsonIgnore]
        public virtual ICollection<MemberCard> MemberCards { get; set; }
    }
}
