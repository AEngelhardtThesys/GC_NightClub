using GC_NightClub.WebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace GC_NightClub.WebAPI
{
    public class NightClubDbContext(DbContextOptions<NightClubDbContext> options) : DbContext(options)
    {
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
