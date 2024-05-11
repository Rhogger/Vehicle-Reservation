using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Entities;

[Table("reservations")]
public class Reservation
{
  [Key]
  public int? reservation_id { get; set; }
  public int vehicle_id { get; set; }
  public DateTime start_date { get; set; }
  public DateTime end_date { get; set; }
  public double? value { get; set; }
  [ForeignKey("payment_id")]
  public Payment? Payment { get; set; }

  public Reservation(int vehicle_id, DateTime start_date, DateTime end_date)
  {
    this.vehicle_id = vehicle_id;
    this.start_date = start_date;
    this.end_date = end_date;
  }

  public bool IsValid()
  {
    if (!IsValidVehicleId()) return false;
    if (!IsValidStartDate()) return false;
    if (!IsValidEndDate()) return false;
    if (!IsValidValue()) return false;
    return true;
  }

  public bool IsValidVehicleId()
  {
    bool valid = true;

    try
    {
      if (vehicle_id < 0) throw new Exception("The vehicle ID is invalid.");
    }
    catch
    {
      valid = false;
    }

    return valid;
  }

  public bool IsValidStartDate()
  {
    bool valid = true;

    try
    {
      if (start_date.Date < DateTime.Now.Date) throw new Exception("The start date is less than the current date.");
    }
    catch
    {
      valid = false;
    }

    return valid;
  }
  public bool IsValidEndDate()
  {
    bool valid = true;

    try
    {
      if (end_date.Date < start_date.Date) throw new Exception("The end date is less than the start date.");
    }
    catch
    {
      valid = false;
    }

    return valid;
  }

  public bool IsValidValue()
  {
    bool valid = true;

    try
    {
      CalculateValue();

      if (value <= 0) throw new Exception("Value is 0 or less.");
    }
    catch
    {
      valid = false;
    }

    return valid;
  }

  protected void CalculateValue()
  {
    TimeSpan difference = this.end_date - this.start_date;
    int numberOfDays = difference.Days;

    value = numberOfDays * 150;
  }
}