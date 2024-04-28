using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Interfaces;

public interface IVehicleService
{
  List<Vehicle> GetByFilter(string? year, string? make, int? passengerCapacity);
  void Add(Vehicle vehicle);
}