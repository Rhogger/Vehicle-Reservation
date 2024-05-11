using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VehicleReservation.Controllers;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Test.Controllers;

public class ReservationControllerTest
{
  private readonly Mock<ILogger<ReservationController>> mockLogger;
  private readonly Mock<IReservationService> mockReservationService;
  private readonly ReservationController controller;

  public ReservationControllerTest()
  {
    mockLogger = new Mock<ILogger<ReservationController>>();
    mockReservationService = new Mock<IReservationService>();
    controller = new ReservationController(mockLogger.Object, mockReservationService.Object);
  }

  [Fact]
  public void HasCorrectAttributes()
  {
    // Assert
    var apiControllerAttribute = Assert.IsType<ApiControllerAttribute>(controller.GetType().GetCustomAttributes(typeof(ApiControllerAttribute), true)[0]);
    Assert.NotNull(apiControllerAttribute);

    var routeAttribute = Assert.IsType<RouteAttribute>(controller.GetType().GetCustomAttributes(typeof(RouteAttribute), true)[0]);
    Assert.NotNull(routeAttribute);
    Assert.Equal("[controller]/[action]", routeAttribute.Template);
  }

  [Fact]
  public void GetByFilter_ReturnsOkResult()
  {
    // Arrange
    List<Reservation> expectedReservations = new List<Reservation>
            {
                new Reservation(18, DateTime.Now, DateTime.Now.AddDays(4)),
                new Reservation(16, DateTime.Now, DateTime.Now.AddDays(3)),
                new Reservation(15, DateTime.Now, DateTime.Now.AddDays(2)),
                new Reservation(19, DateTime.Now, DateTime.Now.AddDays(5)),
            };

    mockReservationService.Setup(service => service.GetByFilter(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>()))
                          .Returns(expectedReservations);

    // Act
    var result = controller.GetByFilter(null, null, null, null);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    var model = Assert.IsAssignableFrom<IEnumerable<Reservation>>(okResult.Value);
    Assert.Equal(expectedReservations, model);
  }

  [Fact]
  public void GetByFilter_ReturnsNotFound_WhenNoReservationsFound()
  {
    // Arrange
    mockReservationService.Setup(service => service.GetByFilter(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>()))
                          .Returns(new List<Reservation>());

    // Act
    var result = controller.GetByFilter(null, null, null, null);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("No reservations found for the specified filter.", notFoundResult.Value);
  }

  [Fact]
  public void Create_ReturnsCreatedAtActionResult()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now.AddDays(1);

    ReservationInput inputModel = new ReservationInput(vehicle_id, start_date, end_date);

    Reservation createdReservation = new Reservation(vehicle_id, start_date, end_date);

    mockReservationService.Setup(service => service.Add(It.IsAny<Reservation>()))
                          .Callback<Reservation>(r => createdReservation = r);

    // Act
    var result = controller.Create(inputModel);

    // Assert
    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    var model = Assert.IsAssignableFrom<Reservation>(createdAtActionResult.Value);
    Assert.Equal(inputModel.vehicle_id, model.vehicle_id);
    Assert.Equal(inputModel.start_date, model.start_date);
    Assert.Equal(inputModel.end_date, model.end_date);
  }

  [Fact]
  public void Create_ReturnsBadRequest_WhenBadRequestOccurs()
  {
    // Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now.AddDays(1);

    ReservationInput inputModel = new ReservationInput(vehicle_id, start_date, end_date);

    mockReservationService.Setup(service => service.Add(It.IsAny<Reservation>()))
                          .Throws(new InvalidOperationException("Some other bad request occurred."));

    // Act
    var result = controller.Create(inputModel);

    // Assert
    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
    Assert.Equal("Some other bad request occurred.\nIt was not possible to register the vehicle because there was a problem.", badRequestResult.Value);
  }
}
