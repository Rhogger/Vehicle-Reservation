using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleReservation.Models.Entities;

[Table("payments")]
public class Payment
{
  [Key]
  public int? payment_id { get; set; }
  public int reservation_id { get; set; }
  public double value { get; set; }
  public string type { get; set; }

  public Payment(int reservation_id, double value, string type)
  {
    this.reservation_id = reservation_id;
    this.value = value;
    this.type = type;
  }
}