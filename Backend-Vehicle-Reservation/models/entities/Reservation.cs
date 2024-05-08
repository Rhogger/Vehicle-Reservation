using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;

[Table("reservations")]
public class Reservation
{
  [Key]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public int? reservation_id { get; set; }
  public int vehicle_id { get; set; }
  public DateTime start_date { get; set; }
  public DateTime end_date { get; set; }
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public double? value { get; set; }
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public int? payment_id { get; set; }  
}