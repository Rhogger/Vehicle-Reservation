using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Interfaces;

public interface IVehicleService
{
  List<Vehicle> GetByFilter(string? make, string? model, string? year, string? color, string? plate, int? passengerCapacity);
  void Add(Vehicle vehicle);
  Boolean VehicleMin();
}