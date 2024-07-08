using GC_NightClub.Domain;
using Microsoft.EntityFrameworkCore;

namespace GC_NightClub.Data
{
    public class NightClubDbContext : DbContext
    {
        public NightClubDbContext(DbContextOptions<NightClubDbContext> options) : base(options) { }

        public DbSet<IdentityCard> IdentityCards { get; set; }
        public DbSet<MemberCard> MemberCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberCard>().HasOne(mc => mc.IdentityCard)
                .WithMany(ic => ic.MemberCards)
                .HasForeignKey(mc => mc.IdentityCardId)
                .IsRequired();
        }
    }
}
