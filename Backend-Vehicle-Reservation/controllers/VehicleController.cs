using Microsoft.AspNetCore.Mvc;
using VehicleReservation.Models.Entities;

namespace VehicleReservation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class VehicleController : ControllerBase
{
  private readonly ILogger<VehicleController> _logger;
  private readonly List<Vehicle> vehicles = [];

  public VehicleController(ILogger<VehicleController> logger)
  {
    _logger = logger;
  }

  [HttpPost(Name = "Create vehicle")]
  public IActionResult Create([FromBody] Vehicle vehicle)
  {
    vehicle.Id = vehicles.Count + 1;
    vehicles.Add(vehicle);

    return CreatedAtAction(nameof(Create), new { id = vehicle.Id }, "Vehicle created at successfully");
  }
}

