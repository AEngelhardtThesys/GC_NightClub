using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GC_NightClub.WebAPI.Domain.Interfaces;

namespace GC_NightClub.WebAPI.Domain
{
    public class MemberCard : IEntity<string>
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("BlacklistedUntilDate")]
        public DateTime? BlacklistedUntilDate { get; set; }

        [Column("IdentityCardId")]
        [Required]
        public Guid IdentityCardId { get; set; }

        public virtual IdentityCard IdentityCard { get; set; }
    }
}
