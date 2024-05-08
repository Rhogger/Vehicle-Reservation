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

  [HttpPost(Name = "Create reservation")]
  public IActionResult Create([FromBody] Reservation reservation)
  {
    _reservationService.Add(reservation);

    return CreatedAtAction(nameof(Create), reservation);
  }
}