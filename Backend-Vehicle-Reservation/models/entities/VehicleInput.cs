using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;

public class VehicleInput
{
  public string make { get; set; }
  public string model { get; set; }
  public string year { get; set; }
  public string color { get; set; }
  public string plate { get; set; }
  public int passenger_capacity { get; set; }

  [JsonConstructor]
  public VehicleInput() { }

  public VehicleInput(string make, string model, string year, string color, string plate, int passenger_capacity)
  {
    this.make = make;
    this.model = model;
    this.year = year;
    this.color = color;
    this.plate = plate;
    this.passenger_capacity = passenger_capacity;
  }
}
