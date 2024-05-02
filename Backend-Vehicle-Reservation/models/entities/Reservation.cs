using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;
public class Reservation
{
  private string _id { get; set; }
  private Vehicle _selectedVehicle { get; set; }
  private DateTime _startDate { get; set; }
  private DateTime _endDate { get; set; }
  private float _value { get; set; }
  private Payment _payment { get; set; }

  [JsonIgnore]
  public string Id { get; set; }
  public Vehicle SelectedVehicle { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  [JsonIgnore]
  public float Value { get; set; }
  public Payment Payment { get; set; }
}