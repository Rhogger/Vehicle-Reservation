using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Service;

public class VehicleService : IVehicleService
{
  private readonly List<Vehicle> _vehicles = new List<Vehicle>();

  public List<Vehicle> GetByFilter(string? year, string? make, int? passengerCapacity)
  {
    var vehicles = _vehicles.AsQueryable(); 

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

  public Boolean VehicleMin(){
    int numberOfVehicles = _vehicles.Count;
    Boolean result;
    if (numberOfVehicles > 5)
      result = true;
    else 
      result = false;
    return result;
  }
}