using Microsoft.Extensions.Logging;
using VehicleReservation.Controllers;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace VehicleReservation.Test.Controllers;

public class VehicleControllerTest
{
  private readonly Mock<ILogger<VehicleController>> mockLogger = new Mock<ILogger<VehicleController>>();
  private readonly Mock<IVehicleService> mockVehicleService = new Mock<IVehicleService>();


  [Fact]
  public void Create_ValidVehicle_ReturnsCreatedAtAction()
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0886";
    int passengerCapacity = 5;

    VehicleInput vehicleInput = new VehicleInput(make, model, year, color, plate, passengerCapacity);
    Vehicle vehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    mockVehicleService.Setup(service => service.Add(It.IsAny<Vehicle>()));

    var controller = new VehicleController(mockLogger.Object, mockVehicleService.Object);

    // Act
    var result = controller.Create(vehicleInput);

    // Assert
    Assert.IsType<CreatedAtActionResult>(result);
    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    Assert.Equal(nameof(controller.Create), createdAtActionResult.ActionName);

    mockVehicleService.Verify(service => service.Add(It.IsAny<Vehicle>()), Times.Once);
  }

  [Fact]
  public void Create_InvalidVehicle_ReturnsBadRequest()
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0886";
    int passengerCapacity = 0;

    VehicleInput vehicleInput = new VehicleInput(make, model, year, color, plate, passengerCapacity);

    var controller = new VehicleController(mockLogger.Object, mockVehicleService.Object);

    // Act
    var result = controller.Create(vehicleInput);

    // Assert
    Assert.IsType<BadRequestObjectResult>(result);
  }


  [Fact]
  public void GetByFilter_ReturnsNotFound()
  {
    // Arrange
    string make = "Nissan";

    mockVehicleService.Setup(service => service.GetByFilter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>())).Returns(new List<Vehicle>());

    var controller = new VehicleController(mockLogger.Object, mockVehicleService.Object);

    // Act
    var result = controller.GetByFilter(make, null, null, null, null, null);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("No vehicles found for the specified filter.", notFoundResult.Value);
  }

  [Fact]
  public void GetByFilter_ReturnsOkWithVehicles()
  {
    // Arrange
    string make = "Nissan";
    string model = "Skyline GT-R";
    string year = "2024";
    string color = "Azul";
    string plate = "NGA0886";
    int passengerCapacity = 5;

    var expectedVehicle = new Vehicle(make, model, year, color, plate, passengerCapacity);

    mockVehicleService.Setup(service => service.GetByFilter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>()))
                      .Returns(new List<Vehicle> { expectedVehicle });

    var controller = new VehicleController(mockLogger.Object, mockVehicleService.Object);

    // Act
    var result = controller.GetByFilter(make, model, year, color, plate, passengerCapacity);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    var vehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(okResult.Value);
    Assert.NotEmpty(vehicles);
    Assert.Contains(expectedVehicle, vehicles);
  }

}