using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;

[Table("vehicles")]
public class Vehicle
{
    [Key]
    [JsonIgnore]
    public int? vehicle_id { get; set; }

    public string make { get; set; }
    public string model { get; set; }
    public string year { get; set; }
    public string color { get; set; }
    public string plate { get; set; }
    public int passenger_capacity { get; set; }

    public void Validate()
    {
        if (string.IsNullOrEmpty(make)) throw new ArgumentNullException("Car branch can't be null or empty string.");
        if (string.IsNullOrEmpty(model)) throw new ArgumentNullException("Car model can't be null or empty string.");
        if (string.IsNullOrEmpty(year)) throw new ArgumentNullException("Car year can't be null or empty string.");
        if (string.IsNullOrEmpty(color)) throw new ArgumentNullException("Color of car can't be null or empty string.");
        if (string.IsNullOrEmpty(plate)) throw new ArgumentNullException("Car plate can't be null or empty string.");
        if (passenger_capacity < 1) throw new Exception("The number of passengers cannot be less than 1.");
    }
}
