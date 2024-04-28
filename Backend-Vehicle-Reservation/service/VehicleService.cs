using VehicleReservation.Models.Entities;

public class VehicleService : IVehicleService
{
  private readonly List<Vehicle> _vehicles = new List<Vehicle>();

  public List<Vehicle> GetByFilter(string? year, string? make, int? passengerCapacity)
  {
    var vehicles = _vehicles.AsQueryable(); ;

    if (year != null)
    {
      vehicles = vehicles.Where(v => v.Year == year);
    }

    if (make != null)
    {
      vehicles = vehicles.Where(v => v.Make == make);
    }

    if (passengerCapacity != null)
    {
      vehicles = vehicles.Where(v => v.PassengerCapacity == passengerCapacity);
    }

    return vehicles.ToList();
  }

  public void Add(Vehicle vehicle)
  {
    _vehicles.Add(vehicle);
  }
}