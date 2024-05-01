using System.Text.Json;
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
  public IActionResult GetByFilter([FromQuery] string? year, string? make, int? passengerCapacity)
  {
    var vehicles = _vehicleService.GetByFilter(year, make, passengerCapacity);

    if (vehicles.Any()) return Ok(vehicles);
    else return NotFound("No vehicles found for the specified filter.");
  }

  [HttpPost(Name = "Create vehicle")]
  public IActionResult Create([FromBody] Vehicle vehicle)
  {
    vehicle.Id = Guid.NewGuid().ToString();
    _vehicleService.Add(vehicle);

    return CreatedAtAction(nameof(Create), new { id = vehicle.Id }, vehicle);
  }
}