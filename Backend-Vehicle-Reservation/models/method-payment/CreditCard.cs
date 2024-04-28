namespace VehicleReservation.Models.Utils.Method_Payment;

public class CreditCard : Card
{
  public CreditCard(string cardNumber, double value)
  {
    CardNumber = cardNumber;
    Value = value;
  }
}