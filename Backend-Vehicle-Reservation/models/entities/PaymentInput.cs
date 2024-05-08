namespace VehicleReservation.Models.Entities;
public class PaymentInput
{
  public int reservation_id { get; set; }
  public double value { get; set; }
  public string type { get; set; }

  public PaymentInput(int reservation_id, double value, string type)
  {
    this.reservation_id = reservation_id;
    this.value = value;
    this.type = type;
  }
}