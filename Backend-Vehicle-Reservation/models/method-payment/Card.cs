namespace VehicleReservation.Models.Utils.Method_Payment
{
  public abstract class Card
  {
    public string CardNumber { get; set; }
    public double Value { get; set; }

    public abstract void ProcessPayment();
  }

  public class CreditCard : Card
  {
    public CreditCard(string cardNumber, double value)
    {
      CardNumber = cardNumber;
      Value = value;
    }
  }

  public class DebitCard : Card
  {
    public DebitCard(string cardNumber, double value)
    {
      CardNumber = cardNumber;
      Value = value;
    }
  }
}