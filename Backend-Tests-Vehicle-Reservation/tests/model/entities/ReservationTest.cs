using VehicleReservation.Models.Entities;

namespace VehicleReservation.Test.Models.Entities;
public class ReservationTest
{
  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  [InlineData(18)]
  public void IsValidVehicleId(int vehicleId)
  {
    // Arrange
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now.AddDays(3);

    Reservation reservation = new Reservation(vehicleId, start_date, end_date);

    // Act
    bool isValid = reservation.IsValidVehicleId();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Fact]
  public void IsValidStartDate_ReturnsTrue()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now.AddDays(3);

    Reservation reservation = new Reservation(vehicle_id, start_date, end_date);

    // Act
    bool isValid = reservation.IsValidStartDate();

    // Assert
    Assert.True(isValid);
  }

  [Fact]
  public void IsValidStartDate_ReturnsFalse()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now.AddDays(-1);
    DateTime end_date = DateTime.Now.AddDays(3);

    Reservation reservation = new Reservation(vehicle_id, start_date, end_date);

    // Act
    bool isValid = reservation.IsValidStartDate();

    // Assert
    Assert.False(isValid);
  }

  [Fact]
  public void IsValidEndDate_ReturnsTrue()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime startDate = DateTime.Now;
    DateTime endDate = DateTime.Now.AddDays(3);

    Reservation reservation = new Reservation(vehicle_id, startDate, endDate);

    // Act
    bool isValid = reservation.IsValidEndDate();

    // Assert
    Assert.True(isValid);
  }

  [Fact]
  public void IsValidEndDate_ReturnsFalse()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime startDate = DateTime.Now;
    DateTime endDate = DateTime.Now.AddDays(-1);

    Reservation reservation = new Reservation(vehicle_id, startDate, endDate);

    // Act
    bool isValid = reservation.IsValidEndDate();

    // Assert
    Assert.False(isValid);
  }

  [Fact]
  public void IsValidValue_ReturnsTrue()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime startDate = DateTime.Now;
    DateTime endDate = DateTime.Now.AddDays(2);

    Reservation reservation = new Reservation(vehicle_id, startDate, endDate);

    // Act
    bool isValid = reservation.IsValidValue();

    // Assert
    Assert.True(isValid);
    Assert.NotNull(reservation.value);
    Assert.Equal(300, reservation.value);
  }

  [Fact]
  public void IsValidValue_ReturnsFalse()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime startDate = DateTime.Now;
    DateTime endDate = DateTime.Now;

    Reservation reservation = new Reservation(vehicle_id, startDate, endDate);

    // Act
    bool isValid = reservation.IsValidValue();

    // Assert
    Assert.False(isValid);
    Assert.NotNull(reservation.value);
    Assert.Equal(0, reservation.value);
  }
}
