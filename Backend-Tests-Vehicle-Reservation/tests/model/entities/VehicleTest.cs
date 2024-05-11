using VehicleReservation.Models.Entities;

namespace VehicleReservation.Test.Models.Entities;

public class VehicleTest
{
  [Theory]
  [InlineData("")]
  [InlineData("Nissan")]
  public void IsValidMakeValue(string make)
  {
    // Arrange
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValid = vehicle.IsValidMake();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData("")]
  [InlineData("Skyline GT-R")]
  public void IsValidModelValue(string model)
  {
    // Arrange
    string make = "Nissan";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValid = vehicle.IsValidModel();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("2024")]
  public void IsValidYearValue(string year)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValid = vehicle.IsValidYear();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData("")]
  [InlineData("Azul")]
  public void IsValidColorValue(string color)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValid = vehicle.IsValidColor();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData("")]
  [InlineData("NGA0881")]
  public void IsValidPlateValue(string plate)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValid = vehicle.IsValidPlate();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(1)]
  [InlineData(5)]
  public void IsValidNumberOfPassengersValue(int passengersCapacity)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengersCapacity);

    // Act
    bool isValid = vehicle.IsValidNumberOfPassengers();

    // Assert
    if (isValid) Assert.True(isValid);
    else Assert.False(isValid);
  }
}