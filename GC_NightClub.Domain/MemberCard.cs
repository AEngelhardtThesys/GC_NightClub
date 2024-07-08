using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GC_NightClub.Domain.Interfaces;

namespace GC_NightClub.Domain
{
    public class MemberCard : IEntity<string>
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("IdentityCardId")]
        [Required]
        public Guid IdentityCardId { get; set; }

        public virtual IdentityCard IdentityCard { get; set; }
    }
}
