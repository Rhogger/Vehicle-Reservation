using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Entities;

[Table("reservations")]
public class Reservation
{
  [Key]
  public int? reservation_id { get; set; }
  public int vehicle_id { get; set; }
  public DateTime start_date { get; set; }
  public DateTime end_date { get; set; }
  public double? value { get; set; }
  [NotMapped]
  public Payment? payment { get; set; }

  public Reservation(int vehicle_id, DateTime start_date, DateTime end_date)
  {
    this.vehicle_id = vehicle_id;
    this.start_date = start_date;
    this.end_date = end_date;
  }
}