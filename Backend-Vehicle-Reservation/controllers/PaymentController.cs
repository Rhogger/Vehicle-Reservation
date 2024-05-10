using Microsoft.AspNetCore.Mvc;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PaymentController : ControllerBase
{
  private readonly ILogger<PaymentController> _logger;
  private readonly IPaymentService _paymentService;
  private readonly IReservationService _reservationService;
  public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService, IReservationService reservationService)
  {
    _logger = logger;
    _paymentService = paymentService;
    _reservationService = reservationService;
  }

  [HttpGet(Name = "Get payments by all filters")]
  public IActionResult GetByFilter([FromQuery] int? reservation_id, double? value, string? type)
  {
    var payments = _paymentService.GetByFilter(reservation_id, value, type);

    if (payments.Any())
      return Ok(payments);
    else
      return NotFound("No payments found for the specified filter.");
  }

  [HttpPost(Name = "Create payment")]
  public IActionResult Create([FromBody] PaymentInput inputModel)
  {
    var reservationList = _reservationService.GetByFilter(inputModel.reservation_id, null, null, null);

    if (reservationList == null)
      return NotFound("Reservation not found.");

    var reservation = reservationList.FirstOrDefault();

    var reservationValue = reservation?.value;

    if (!reservationValue.HasValue)
      return BadRequest("Reservation value is not available.");

    var payment = new Payment(inputModel.reservation_id, (double)reservationValue, inputModel.type);

    _paymentService.Add(payment);

    reservation.Payment = payment;

    _reservationService.Update(reservation);

    return CreatedAtAction(nameof(Create), payment);
  }
}