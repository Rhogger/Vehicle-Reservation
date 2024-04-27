namespace VehicleReservation.Models.Entities;

public class Vehicle
{
  private int _id;
  private string _make { get; set; }
  private string _model { get; set; }
  private string _year { get; set; }
  private string _color { get; set; }
  private string _plate { get; set; }
  private int _passengerCapacity { get; set; }

  public int? Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public string Year { get; set; }
  public string Color { get; set; }
  public string Plate { get; set; }
  public int PassengerCapacity { get; set; }
}