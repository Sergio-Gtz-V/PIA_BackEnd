using PIA_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace PIA_BackEnd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Raffle_Participant>()
                .HasOne(r => r.Raffle)
                .WithMany(rp => rp.Raffle_Participants)
                .HasForeignKey(rp => rp.RaffleId);

            modelBuilder.Entity<Raffle_Participant>()
                .HasOne(p => p.Participant)
                .WithMany(rp => rp.Raffle_Participants)
                .HasForeignKey(p => p.ParticipantId);
        }

        public DbSet<Raffle> Rifas { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Prizes> Prizes { get; set; }

        public DbSet<Raffle_Participant> Raffle_Participants { get; set; }
    }
}
