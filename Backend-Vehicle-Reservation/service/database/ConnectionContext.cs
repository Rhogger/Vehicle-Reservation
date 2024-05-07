using Microsoft.EntityFrameworkCore;
using VehicleReservation.Models.Entities;

namespace VehicleReservation.Database;

public class ConnectionContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("string de conexão");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>().ToTable("vehicles");
    }
}
