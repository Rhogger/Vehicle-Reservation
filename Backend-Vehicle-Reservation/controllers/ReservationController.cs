using Microsoft.AspNetCore.Mvc;

namespace VehicleReservation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
  private readonly ILogger<ReservationController> _logger;

  public ReservationController(ILogger<ReservationController> logger)
  {
    _logger = logger;
  }

}

