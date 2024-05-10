namespace VehicleReservation.Models.Entities;
public class PaymentInput
{
  public int reservation_id { get; set; }
  public string type { get; set; }

  public PaymentInput(int reservation_id, string type)
  {
    this.reservation_id = reservation_id;
    this.type = type;
  }
}