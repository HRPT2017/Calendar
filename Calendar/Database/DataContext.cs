using Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Database
{

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder opitionsBuilder)
        {
            opitionsBuilder.EnableSensitiveDataLogging();


            opitionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\\Calendar.mdf; Integrated Security = True");
        }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCompetition> EventsCompetitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships here
            modelBuilder.Entity<Competition>()
                .HasOne(c => c.modality)
                .WithMany(m => m.competition)
                .HasForeignKey(c => c.modalityId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.modality)
                .WithMany(c => c.events)
                .HasForeignKey(e => e.modalityId);

            modelBuilder.Entity<EventCompetition>()
                        .HasKey(j => new { j.competitionId, j.eventId });

            modelBuilder.Entity<EventCompetition>()
                        .HasOne(t => t.events)
                        .WithMany(j => j.eventConpetition)
                        .HasForeignKey(j => j.eventId);

            modelBuilder.Entity<EventCompetition>()
                        .HasOne(t => t.competition)
                        .WithMany(j => j.eventCompetition)
                        .HasForeignKey(j => j.competitionId);



        }

    }
}
