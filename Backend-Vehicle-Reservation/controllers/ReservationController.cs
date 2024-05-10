using Microsoft.AspNetCore.Mvc;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ReservationController : ControllerBase
{
  private readonly ILogger<ReservationController> _logger;
  private readonly IReservationService _reservationService;
  public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
  {
    _logger = logger;
    _reservationService = reservationService;
  }

  [HttpGet(Name = "Get reservations by all filters")]
  public IActionResult GetByFilter([FromQuery] int? reservation_id, int? vehicle_id, DateTime? startDate, DateTime? endDate)
  {
    var reservations = _reservationService.GetByFilter(reservation_id, vehicle_id, startDate, endDate);

    if (reservations.Any())
      return Ok(reservations);
    else
      return NotFound("No reservations found for the specified filter.");
  }

  [HttpPost(Name = "Create reservation")]
  public IActionResult Create([FromBody] ReservationInput inputModel)
  {
    var reservation = new Reservation(inputModel.vehicle_id, inputModel.start_date, inputModel.end_date);

    _reservationService.Add(reservation);

    return CreatedAtAction(nameof(Create), reservation);
  }
}