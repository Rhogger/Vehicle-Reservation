namespace VehicleReservation.Models.Utils.Method_Payment;

public class DebitCard : Card
{
  public DebitCard(string cardNumber, double value)
  {
    CardNumber = cardNumber;
    Value = value;
  }
}