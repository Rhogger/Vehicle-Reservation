using VehicleReservation.Models.Entities;

namespace VehicleReservation.Test.Models.Entities;

public class PaymentTest
{
  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  [InlineData(9)]
  public void IsValidReservationId(int reservation_id)
  {
    // Arrange
    double value = 300;
    string type = "boleto";

    Payment payment = new Payment(reservation_id, value, type);

    // Act
    bool isValid = payment.IsValidReservationId();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(300)]
  public void IsValidValue(double value)
  {
    // Arrange
    int reservation_id = 9;
    string type = "boleto";

    Payment payment = new Payment(reservation_id, value, type);

    // Act
    bool isValid = payment.IsValidValue();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData("")]
  [InlineData("pix")]
  [InlineData("dinheiro")]
  [InlineData("boleto")]
  [InlineData("cartao_credito")]
  [InlineData("cartao_debito")]
  public void IsValidPaymentWay(string type)
  {
    // Arrange
    int reservation_id = 9;
    double value = 300;

    Payment payment = new Payment(reservation_id, value, type);

    // Act
    bool isValid = payment.IsValidType();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }
}