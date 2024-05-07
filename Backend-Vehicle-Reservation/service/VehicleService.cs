using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;
using VehicleReservation.Database;

namespace VehicleReservation.Service;

public class VehicleService : IVehicleService
{
  private readonly ConnectionContext _context;

  public VehicleService(ConnectionContext context)
  {
    _context = context;
  }
  public List<Vehicle> GetByFilter(string? year, string? make, int? passengerCapacity)
  {
    IQueryable<Vehicle> vehicles = _context.Set<Vehicle>();

    if (year != null)
    {
      vehicles = vehicles.Where(v => v.year == year);
    }

    if (make != null)
    {
      vehicles = vehicles.Where(v => v.make == make);
    }

    if (passengerCapacity != null)
    {
      vehicles = vehicles.Where(v => v.passenger_capacity == passengerCapacity);
    }

    return vehicles.ToList();
  }

  public void Add(Vehicle vehicle)
  {
    _context.Set<Vehicle>().Add(vehicle);
    _context.SaveChanges();
  }

  public Boolean VehicleMin()
  {
    int numberOfVehicles = _context.Set<Vehicle>().Count();
    return numberOfVehicles > 5;
  }
}