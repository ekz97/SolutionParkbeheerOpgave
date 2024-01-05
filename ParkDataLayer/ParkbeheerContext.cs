using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;

namespace ParkDataLayer
{
    public class ParkbeheerContext : DbContext
    {
        public DbSet<ParkEF> Parken { get; set; }
        public DbSet<HuisEF> Huizen { get; set; }
        public DbSet<HuurderEF> Huurders { get; set; }
        public DbSet<HuurcontractEF> Huurcontracten { get; set; }
        public DbSet<HuisHuurderEF> HuisHuurders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Hier kun je de connection string direct opgeven
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Parkbeheer;Integrated Security=True;TrustServerCertificate=true");

            optionsBuilder.UseLazyLoadingProxies();
        }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<HuisHuurderEF>()
        .HasKey(hh => new { hh.HuisEFId, hh.HuurderEFId });

    modelBuilder.Entity<HuisHuurderEF>()
        .HasOne(hh => hh.Huis)
        .WithMany(h => h.HuisHuurders)
        .HasForeignKey(hh => hh.HuisEFId)
        .OnDelete(DeleteBehavior.Cascade); // Cascade delete voor HuisEF-HuisHuurderEF-relatie

    modelBuilder.Entity<HuisHuurderEF>()
        .HasOne(hh => hh.Huurder)
        .WithMany(h => h.GehuurdeHuizen)
        .HasForeignKey(hh => hh.HuurderEFId);

    modelBuilder.Entity<HuurcontractEF>()
        .HasOne(hc => hc.Huurder)
        .WithMany()
        .HasForeignKey(hc => hc.HuurderId)
        .OnDelete(DeleteBehavior.Cascade); // Cascade delete voor HuurcontractEF-HuurderEF-relatie

    modelBuilder.Entity<HuurcontractEF>()
        .HasOne(hc => hc.Huis)
        .WithMany()
        .HasForeignKey(hc => hc.HuisId)
        .OnDelete(DeleteBehavior.Cascade); // Cascade delete voor HuurcontractEF-HuisEF-relatie

    base.OnModelCreating(modelBuilder);
}

    }
}
