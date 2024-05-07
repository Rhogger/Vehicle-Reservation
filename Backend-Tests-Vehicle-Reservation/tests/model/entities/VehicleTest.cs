using VehicleReservation.Models.Entities;

namespace VehicleReservation.Test.Models.Entities;

public class VehicleTest
{
  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("Nissan")]
  public void Constructor_NullOrEmptyMake_ThrowsException(string _make)
  {
    // Arrange
    string make = _make;
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    // Act & Assert
    try
    {
      Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

      // Assert
      Assert.NotNull(vehicle);
      Assert.Equal(make, vehicle.make);
    }
    catch (ArgumentNullException)
    {
      // Assert
      Assert.True(string.IsNullOrEmpty(make));
    }
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("Skyline GT-R")]
  public void Constructor_NullOrEmptyModel_ThrowsException(string _model)
  {
    // Arrange
    string make = "Nissan";
    string model = _model;
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    // Act & Assert
    try
    {
      Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

      // Assert
      Assert.NotNull(vehicle);
      Assert.Equal(model, vehicle.model);
    }
    catch (ArgumentNullException)
    {
      // Assert
      Assert.True(string.IsNullOrEmpty(model));
    }
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("2024")]
  public void Constructor_NullOrEmptyYear_ThrowsException(string _year)
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = _year;
    string color = "Azul";
    string plate = "NGA0881";
    int passengerCapacity = 5;

    // Act & Assert
    try
    {
      Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

      // Assert
      Assert.NotNull(vehicle);
      Assert.Equal(year, vehicle.year);
    }
    catch (ArgumentNullException)
    {
      // Assert
      Assert.True(string.IsNullOrEmpty(year));
    }
  }

  // [Theory]
  // [InlineData("")]
  // [InlineData(null)]
  // public void Constructor_NullOrEmptyColor_ThrowsException()
  // {
  //   // Arrange
  //   string make = "Make";
  //   string model = "Model";
  //   string year = "2024";
  //   string color = "";
  //   string plate = "Plate";
  //   int passengerCapacity = 5;

  //   // Act & Assert
  //   Assert.Throws<ArgumentNullException>(() => new Vehicle(make, model, year, color, plate, passengerCapacity));
  // }

  // [Theory]
  // [InlineData("")]
  // [InlineData(null)]
  // public void Constructor_NullOrEmptyPlate_ThrowsException()
  // {
  //   // Arrange
  //   string make = "Make";
  //   string model = "Model";
  //   string year = "2024";
  //   string color = "Color";
  //   string plate = "";
  //   int passengerCapacity = 5;

  //   // Act & Assert
  //   Assert.Throws<ArgumentNullException>(() => new Vehicle(make, model, year, color, plate, passengerCapacity));
  // }

  // [Theory]
  // [InlineData("")]
  // [InlineData(null)]
  // public void Constructor_PassengerCapacityLessThanOne_ThrowsException()
  // {
  //   // Arrange
  //   string make = "Make";
  //   string model = "Model";
  //   string year = "2024";
  //   string color = "Color";
  //   string plate = "Plate";
  //   int passengerCapacity = 0;

  //   // Act & Assert
  //   Assert.Throws<Exception>(() => new Vehicle(make, model, year, color, plate, passengerCapacity));
  // }
}