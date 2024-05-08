using Microsoft.AspNetCore.Mvc;
using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class VehicleController : ControllerBase
{
  private readonly ILogger<VehicleController> _logger;
  private readonly IVehicleService _vehicleService;
  public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
  {
    _logger = logger;
    _vehicleService = vehicleService;
  }

  [HttpGet(Name = "Get vehicles by all filters")]
  public IActionResult GetByFilter([FromQuery] string? make, string? model, string? year, string? color, string? plate, int? passengerCapacity)
  {
    var vehicles = _vehicleService.GetByFilter(make, model, year, color, plate, passengerCapacity);

    if (vehicles.Any()) 
      return Ok(vehicles);
    else 
      return NotFound("No vehicles found for the specified filter.");
  }

  [HttpPost(Name = "Create vehicle")]
  public IActionResult Create([FromBody] Vehicle vehicle)
  {
    _vehicleService.Add(vehicle);

    return CreatedAtAction(nameof(GetByFilter), vehicle);
  }
}