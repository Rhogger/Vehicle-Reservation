using Microsoft.AspNetCore.Mvc;
using VehicleReservation.Enums;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PaymentController : ControllerBase
{
  private readonly ILogger<ReservationController> _logger;
  private readonly IPaymentService _paymentService;
  public PaymentController(ILogger<ReservationController> logger, IPaymentService paymentService)
  {
    _logger = logger;
    _paymentService = paymentService;
  }

  [HttpGet(Name = "Get payments by all filters")]
  public IActionResult GetByFilter([FromQuery] int? reservation_id, double? value, PaymentType? type)
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
    var payment = new Payment(inputModel.reservation_id, inputModel.value, inputModel.type);

    _paymentService.Add(payment);

    return CreatedAtAction(nameof(Create), payment);
  }
}