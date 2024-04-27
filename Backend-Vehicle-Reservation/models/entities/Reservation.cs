namespace VehicleReservation.Models.Entities;
public class Reservation
{
  public Vehicle SelectedVehicle { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }

  public Reservation(Vehicle vehicle, DateTime startDate, DateTime endDate)
  {
    SelectedVehicle = vehicle;
    StartDate = startDate;
    EndDate = endDate;
  }
}