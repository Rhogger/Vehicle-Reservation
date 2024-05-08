using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleReservation.Enums;
using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;

[Table("payments")]
public class Payment
{
  [Key]
  public string payment_id { get; set; }  
  public int reservation_id { get; set; }
  public double value { get; set; }  
  public PaymentType type {get; set; }

  public Payment(int reservation_id, double value, PaymentType type)
  {
    this.reservation_id = reservation_id;
    this.value = value;
    this.type = type;
  } 
  public string ConvertPaymentTypeEnum()
  {
    if (type == PaymentType.cartao_credito) return "Cartão de Crédito";
    if (type == PaymentType.cartao_debito) return "Cartão de Débito";
    return "Boleto";
  }
}