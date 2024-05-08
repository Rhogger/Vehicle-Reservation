using System.Text.Json.Serialization;
using VehicleReservation.Enums;

namespace VehicleReservation.Models.Entities;
public class PaymentInput
{
  public int reservation_id { get; set; }
  public double value { get; set; }  
  public PaymentType type {get; set; }

  public PaymentInput(int reservation_id, double value, PaymentType type)
  {
    this.reservation_id = reservation_id;
    this.value = value;
    this.type = type;
  } 
}