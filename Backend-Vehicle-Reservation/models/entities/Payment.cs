using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;
public class Payment
{
  private string _id { get; set; }  
  private string _name { get; set; }
  private float _value { get; set; }  
  private string _type {get; set; }


  [JsonIgnore]
  public string Id { get; set; }
  public string Name { get; set; }
  public float Value { get; set; }
  public string Type { get; set; }
}