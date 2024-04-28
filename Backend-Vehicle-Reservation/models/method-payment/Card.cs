namespace VehicleReservation.Models.Utils.Method_Payment
{
  public abstract class Card
  {
    private string _cardNumber { get; set; }
    private double _value { get; set; }

    public string CardNumber { get; set; }
    public double Value { get; set; }
  }
}