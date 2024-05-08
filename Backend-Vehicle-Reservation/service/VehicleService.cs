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
  
  public List<Vehicle> GetByFilter(string? make, string? model, string? year, string? color, string? plate, int? passengerCapacity)
  {
    IQueryable<Vehicle> vehicles = _context.Set<Vehicle>();

    if (make != null)
      vehicles = vehicles.Where(v => v.make == make);  

    if (model != null)
      vehicles = vehicles.Where(v => v.model == model); 
    
    if (year != null)
      vehicles = vehicles.Where(v => v.year == year);  

    if (color != null)
      vehicles = vehicles.Where(v => v.color == color); 

    if (plate != null)
      vehicles = vehicles.Where(v => v.plate == plate); 

    if (passengerCapacity != null)
      vehicles = vehicles.Where(v => v.passenger_capacity == passengerCapacity);

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
    return numberOfVehicles >= 5;
  }
}