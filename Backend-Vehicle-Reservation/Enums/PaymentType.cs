using System.Text.Json.Serialization;

namespace VehicleReservation.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentType
{
  cartao_credito,
  cartao_debito,
  boleto
}