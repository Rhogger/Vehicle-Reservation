using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleReservation.Models.Entities;

[Table("payments")]
public class Payment
{
  [Key]
  public int? payment_id { get; set; }
  public int reservation_id { get; set; }
  public double value { get; set; }
  public string type { get; set; }

  public Payment(int reservation_id, double value, string type)
  {
    this.reservation_id = reservation_id;
    this.value = value;
    this.type = type.ToLower();
  }

  public bool IsValid()
  {
    if (!IsValidReservationId()) return false;
    if (!IsValidValue()) return false;
    if (!IsValidType()) return false;

    return true;
  }

  public bool IsValidReservationId()
  {
    bool valid = true;

    try
    {
      if (reservation_id < 0) throw new Exception("The reservation ID is invalid.");
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
      if (value <= 0) throw new Exception("Value of payment is 0 or less.");
    }
    catch
    {
      valid = false;
    }

    return valid;
  }

  public bool IsValidType()
  {
    bool valid = true;

    try
    {
      if (string.IsNullOrEmpty(type)) throw new ArgumentNullException("Type of payment can't be null or empty string.");
      if (type != "boleto" && type != "cartao_credito" && type != "cartao_debito") throw new ArgumentOutOfRangeException("Payment way is invalid.");
    }
    catch
    {
      valid = false;
    }

    return valid;
  }
}