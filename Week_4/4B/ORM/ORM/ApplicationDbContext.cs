using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORM
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Fabrikant> Fabrikanten { get; set; }
        public DbSet<Model> Modellen { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Koper> Kopers { get; set; }
        public DbSet<Verzekering> Verzekeringen { get; set; }
        public DbSet<WA> WaVerzekeringen { get; set; }
        public DbSet<WAPlus> WaPlusVerzekeringen { get; set; }
        public DbSet<AllRisk> AllRiskVerzekeringen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Autofabrikant.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API setup keys.
            modelBuilder.Entity<Auto>().HasKey(a => a.Kenteken);
            modelBuilder.Entity<Fabrikant>().HasKey(f => f.FabrikantId);
            modelBuilder.Entity<Model>().HasKey(m => m.ModelId);

            modelBuilder.Entity<Model>().HasData(
                new Model()
                {
                    Merk = "BMW", ModelId = 1, Serie = "Series 2", Type = "Low Rider"
                },
                new Model()
                {
                    Merk = "Ford", ModelId = 2, Serie = "GT40", Type = "Sports Classic"
                },
                new Model()
                {
                    Merk = "Tesla", ModelId = 3, Serie = "model X", Type = "EV Sports"
                }
            );

            modelBuilder.Entity<Fabrikant>().HasData(
                new Fabrikant()
                {
                    FabrikantId = 1, Adres = "Johannes straat 21", Email = "info@bmw.nl", Naam = "BMW",
                    TelefoonNummer = "0652551489"
                },
                new Fabrikant()
                {
                    FabrikantId = 2, Adres = "Pieterson straat 21", Email = "info@ford.nl", Naam = "Ford",
                    TelefoonNummer = "0652114859"
                },
                new Fabrikant()
                {
                    FabrikantId = 3, Adres = "Jantjeslaan 5102", Email = "info@tesla.nl", Naam = "Tesla",
                    TelefoonNummer = "0105215698"
                }
            );
            
            modelBuilder.Entity<WA>().HasData(
                new WA()
                {
                    Id = 1, Omschrijving = "De basisverzekring", Prijs = 29.99, Verzekeraar = "DE verzekerboer"
                });
            modelBuilder.Entity<WAPlus>().HasData(
                new WAPlus()
                {
                    Id = 2, Omschrijving = "De verzekering met net iets meer", Prijs = 50.00,
                    Verzekeraar = "De verzeker prins"
                });
            modelBuilder.Entity<AllRisk>().HasData(new AllRisk()
            {
                Id = 3, Omschrijving = "De beste verzekering voor alle schade", Prijs = 100.00,
                Verzekeraar = "De verzekerkoning"
            });
        }
    }
}