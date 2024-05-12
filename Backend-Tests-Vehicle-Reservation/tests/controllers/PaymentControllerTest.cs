using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VehicleReservation.Controllers;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Test.Controllers;

public class PaymentControllerTest
{
  private readonly Mock<ILogger<PaymentController>> logger;
  private readonly Mock<IPaymentService> mockPaymentService;
  private readonly Mock<IReservationService> mockReservationService;
  private readonly PaymentController controller;

  public PaymentControllerTest()
  {
    logger = new Mock<ILogger<PaymentController>>();
    mockPaymentService = new Mock<IPaymentService>();
    mockReservationService = new Mock<IReservationService>();
    controller = new PaymentController(logger.Object, mockPaymentService.Object, mockReservationService.Object);
  }

  [Fact]
  public void GetByFilter_ReturnsOk()
  {
    //Arrange
    int reservation_id = 9;
    double value = 300;
    string type = "boleto";

    Payment expectedPayment = new Payment(reservation_id, value, type);

    mockPaymentService.Setup(service => service
    .GetByFilter(
      It.IsAny<int>(),
      It.IsAny<double>(),
      It.IsAny<string>()
      )
    )
    .Returns(new List<Payment>() { expectedPayment });

    //Act 
    var result = controller.GetByFilter(reservation_id, value, type);

    //Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    var payments = Assert.IsAssignableFrom<IEnumerable<Payment>>(okResult.Value);
    Assert.NotEmpty(payments);
    Assert.Contains(expectedPayment, payments);
  }

  [Fact]
  public void GetByFilter_ReturnsNotFound()
  {
    //Arrange
    double value = 325;

    mockPaymentService.Setup(service => service
    .GetByFilter(
      It.IsAny<int?>(),
      It.IsAny<double?>(),
      It.IsAny<string>()
      )
    )
    .Returns(new List<Payment>());

    //Act 
    var result = controller.GetByFilter(null, value, null);

    //Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("No payments found for the specified filter.", notFoundResult.Value);
  }

  [Fact]
  public void Create_ValidPayment_ReturnsCreatedAction()
  {
    //Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now.AddDays(4);

    int reservation_id = 9;
    string type = "boleto";

    PaymentInput inputModel = new PaymentInput(reservation_id, type);

    List<Reservation> expectedReservations = new List<Reservation>
            {
                new Reservation(reservation_id, vehicle_id, start_date, end_date),
            };

    Reservation reservation = expectedReservations.FirstOrDefault();

    reservation.IsValidValue();

    Payment createdPayment = new Payment(inputModel.reservation_id, (double)reservation.value, inputModel.type);

    mockReservationService.Setup(service => service
    .GetByFilter(
      It.IsAny<int?>(),
      null,
      null,
      null
      )
    )
    .Returns(expectedReservations);

    mockPaymentService.Setup(service => service.Add(It.IsAny<Payment>()));

    //Act 
    var result = controller.Create(inputModel);

    // Assert
    var createdActionResult = Assert.IsType<CreatedAtActionResult>(result);
    var model = Assert.IsAssignableFrom<Payment>(createdActionResult.Value);
    Assert.Equal(createdPayment.reservation_id, model.reservation_id);
    Assert.Equal(createdPayment.value, model.value);
    Assert.Equal(createdPayment.type, model.type);
  }

  [Fact]
  public void Create_ReturnsBadRequest_OnPaymentValidation()
  {
    //Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now.AddDays(4);

    int reservation_id = 9;
    string type = "pix";

    PaymentInput inputModel = new PaymentInput(reservation_id, type);

    List<Reservation> expectedReservations = new List<Reservation>
            {
                new Reservation(reservation_id, vehicle_id, start_date, end_date),
            };

    Reservation reservation = expectedReservations.FirstOrDefault();

    reservation.IsValidValue();

    Payment createdPayment = new Payment(inputModel.reservation_id, (double)reservation.value, inputModel.type);

    mockReservationService.Setup(service => service
    .GetByFilter(
      It.IsAny<int?>(),
      null,
      null,
      null
      )
    )
    .Returns(expectedReservations);

    //Act 
    var result = controller.Create(inputModel);

    // Assert
    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
    Assert.Equal("The object could not be created because some parameter was filled in incorrectly.", badRequestResult.Value);
  }

  [Fact]
  public void Create_ReturnsBadRequest_OnReservationValueValidation()
  {
    //Arrange
    int vehicle_id = 18;
    DateTime start_date = DateTime.Now;
    DateTime end_date = DateTime.Now;

    int reservation_id = 9;
    string type = "boleto";

    PaymentInput inputModel = new PaymentInput(reservation_id, type);

    List<Reservation> expectedReservations = new List<Reservation>
            {
                new Reservation(reservation_id, vehicle_id, start_date, end_date),
            };

    mockReservationService.Setup(service => service
    .GetByFilter(
      It.IsAny<int?>(),
      null,
      null,
      null
      )
    )
    .Returns(expectedReservations);

    //Act 
    var result = controller.Create(inputModel);

    // Assert
    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
    Assert.Equal("Reservation is free? This is not possible.", badRequestResult.Value);
  }

  [Fact]
  public void Create_ReturnsNotFound()
  {
    //Arrange
    int reservation_id = 9;
    string type = "boleto";

    PaymentInput inputModel = new PaymentInput(reservation_id, type);

    mockReservationService.Setup(service => service
    .GetByFilter(
      It.IsAny<int?>(),
      null,
      null,
      null
      )
    )
    .Returns(new List<Reservation>());

    //Act 
    var result = controller.Create(inputModel);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("Reservation not found.", notFoundResult.Value);
  }
}