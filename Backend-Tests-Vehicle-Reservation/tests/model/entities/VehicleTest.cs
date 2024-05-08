using VehicleReservation.Models.Entities;

namespace VehicleReservation.Test.Models.Entities;

public class VehicleTest
{
  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("Nissan")]
  public void IsValidMakeValue(string _make)
  {
    // Arrange
    string make = _make;
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValidMake = vehicle.IsValidMake();

    // Assert
    if (!string.IsNullOrEmpty(make))
    {
      Assert.True(isValidMake);
    }
    else
    {
      Assert.False(isValidMake);
    }
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("Skyline GT-R")]
  public void IsValidModelValue(string _model)
  {
    // Arrange
    string make = "Nissan";
    string model = _model;
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValidModel = vehicle.IsValidModel();

    // Assert
    if (!string.IsNullOrEmpty(model))
    {
      Assert.True(isValidModel);
    }
    else
    {
      Assert.False(isValidModel);
    }
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("2024")]
  public void IsValidYearValue(string _year)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = _year;
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValidYear = vehicle.IsValidYear();

    // Assert
    if (!string.IsNullOrEmpty(year))
    {
      Assert.True(isValidYear);
    }
    else
    {
      Assert.False(isValidYear);
    }
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("Azul")]
  public void IsValidColorValue(string _color)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = _color;
    string plate = "NGA0881";
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValidColor = vehicle.IsValidColor();

    // Assert
    if (!string.IsNullOrEmpty(color))
    {
      Assert.True(isValidColor);
    }
    else
    {
      Assert.False(isValidColor);
    }
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("NGA0881")]
  public void IsValidPlateValue(string _plate)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = _plate;
    int passengerCapacity = 5;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValidPlate = vehicle.IsValidPlate();

    // Assert
    if (!string.IsNullOrEmpty(plate))
    {
      Assert.True(isValidPlate);
    }
    else
    {
      Assert.False(isValidPlate);
    }
  }

  [Theory]
  [InlineData(0)]
  [InlineData(1)]
  [InlineData(5)]
  public void IsValidNumberOfPassengersValue(int _passengersCapacity)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = _passengersCapacity;

    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    // Act
    bool isValidNumberOfPassengers = vehicle.IsValidNumberOfPassengers();

    // Assert
    if (passengerCapacity < 1)
    {
      Assert.False(isValidNumberOfPassengers);
    }
    else
    {
      Assert.True(isValidNumberOfPassengers);
    }
  }
}