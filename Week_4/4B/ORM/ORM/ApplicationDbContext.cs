using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORM
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Fabrikant> Fabrikanten { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Model> Modellen { get; set; }
        public DbSet<Koper> Kopers { get; set; }
        public DbSet<Verzekering> Verzekeringen { get; set; }
        public DbSet<WA> WaVerzekeringen { get; set; }
        public DbSet<WAPlus> WaPlusVerzekeringen { get; set; }
        public DbSet<AllRisk> AllRiskVerzekeringen { get; set; }
    }
}