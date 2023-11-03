using Beco_tours.Models;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Vozilo> Vozila { get; set; }
        public DbSet<Vozac> Vozace { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<Tura> Ture { get; set; }
        public DbSet<Putnik> Putnike { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }

    }
}


