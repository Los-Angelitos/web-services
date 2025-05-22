using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.Reservations.Application.Internal.CommandServices;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;
using SweetManagerIotWebService.API.Reservations.Domain.Services.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class ThermostatController(IThermostatCommandService thermostatCommandService, IThermostatQueryServices thermostatQueryServices) : ControllerBase
{
    [HttpPut("update-thermostat-state")]
    public async Task<IActionResult> UpdateThermostatState([FromBody] UpdateThermostatStateResource resource)
    {
        var result = await thermostatCommandService.Handle(
            UpdateThermostatStateCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpGet("get-thermostat-by-id")]
    public async Task<IActionResult> ThermostatById([FromQuery] int id)
    {
        var thermostat = await thermostatQueryServices.Handle(new GetThermostatByIdQuery(id));
        if (thermostat is null)
            return BadRequest();

        var thermostatResource = ThermostatResourceFromEntityAssembler
            .FromEntity(thermostat);
        return Ok(thermostatResource);
    }
    
    [HttpGet("get-all-thermostats")]
    public async Task<IActionResult> GetAllThermostats([FromQuery] int hotelId)
    {
        var thermostats = await thermostatQueryServices.Handle(new GetAllThermostatsByHotelIdQuery(hotelId));
        if (thermostats is null)
            return BadRequest();
        var thermostatResources = thermostats.Select(ThermostatResourceFromEntityAssembler.FromEntity);
        return Ok(thermostatResources);
    }
    
    [HttpPost("create-thermostat")]
    public async Task<IActionResult> CreateThermostat([FromBody] CreateThermostatResource resource)
    {
        try
        {
            var command = CreateThermostatCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await thermostatCommandService.Handle(command);

            return Ok("Thermostat created successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[CreateThermostat] Argument error: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                error = ex.Message,
                stack = ex.StackTrace
            });
        }
    }
    
    [HttpPut("update-thermostat-temperature")]
    public async Task<IActionResult> UpdateThermostatTemperature([FromBody] UpdateThermostatTemperatureResource resource)
    {
        var result = await thermostatCommandService.Handle(
            UpdateThermostatTemperatureCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpPut("update-thermostat")]
    public async Task<IActionResult> UpdateThermostat([FromBody] UpdateThermostatResource resource)
    {
        var result = await thermostatCommandService.Handle(
            UpdateThermostatCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    
}