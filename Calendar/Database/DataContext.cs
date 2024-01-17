using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder opitionsBuilder)
        {
            opitionsBuilder.EnableSensitiveDataLogging();


            opitionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\\Calendar.mdf; Integrated Security = True");
        }
        public DbSet<Modalidade> Modalidade { get; set; }
        public DbSet<Competicao> Competicao { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<JunctionTable> JunctionTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships here
            modelBuilder.Entity<Competicao>()
                .HasOne(c => c.Modalidade)
                .WithMany(m => m.Competicao)
                .HasForeignKey(c => c.Modalidade_Id);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Modalidade)
                .WithMany(c => c.Evento)
                .HasForeignKey(e => e.Modalidade_Id);

            modelBuilder.Entity<JunctionTable>()
                        .HasKey(j => new { j.Competicao_Id, j.Evento_Id });

            modelBuilder.Entity<JunctionTable>()
                        .HasOne(t => t.Evento)
                        .WithMany(j => j.JunctionTable)
                        .HasForeignKey(j => j.Evento_Id);

            modelBuilder.Entity<JunctionTable>()
                        .HasOne(t => t.Competicao)
                        .WithMany(j => j.JunctionTable)
                        .HasForeignKey(j => j.Competicao_Id);



        }

    }
}
