using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;

public class ReservationInput
{
  public int vehicle_id { get; set; }
  public DateTime start_date { get; set; }
  public DateTime end_date { get; set; }
  [JsonConstructor]
  public ReservationInput() { }

  public ReservationInput(int vehicle_id, DateTime start_date, DateTime end_date)
  {
    this.vehicle_id = vehicle_id;
    this.start_date = start_date;
    this.end_date = end_date;
  }
}