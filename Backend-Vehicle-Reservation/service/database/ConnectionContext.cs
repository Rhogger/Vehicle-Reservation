using Microsoft.EntityFrameworkCore;
using VehicleReservation.Models.Entities;

namespace VehicleReservation.Database;

public class ConnectionContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    // private string ConnectionString { get; set; }
    // public ConnectionContext(IConfiguration configuration)
    // {
    //     ConnectionString = configuration.GetConnectionString("Default");
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>().ToTable("vehicles");
        modelBuilder.Entity<Reservation>().ToTable("reservations");
    }
}
