using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;
using SweetManagerIotWebService.API.Reservations.Domain.Services.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.SmokeSensor;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class SmokesensorController(ISmokeSensorCommandService smokesensorCommandService, ISmokeSensorQueryServices smokesensorQueryServices) : ControllerBase
{
    [HttpPut("update-smoke-sensor-state")]
    public async Task<IActionResult> UpdateSmokeSensorState([FromBody] UpdateSmokeSensorStateResource resource)
    {
        var result = await smokesensorCommandService.Handle(
            UpdateSmokeSensorStateCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpGet("get-smoke-sensor-by-id")]
    public async Task<IActionResult> smokesensorById([FromQuery] int id)
    {
        var smokesensor = await smokesensorQueryServices.Handle(new GetSmokeSensorByIdQuery(id));
        if (smokesensor is null)
            return BadRequest();

        var smokesensorResource = SmokeSensorResourceFromEntityAssembler
            .FromEntity(smokesensor);
        return Ok(smokesensorResource);
    }
    
    [HttpGet("get-all-smoke-sensors")]
    public async Task<IActionResult> GetAllSmokeSensors([FromQuery] int hotelId)
    {
        var smokesensors = await smokesensorQueryServices.Handle(new GetAllSmokeSensorsByHotelIdQuery(hotelId));
        if (smokesensors is null)
            return BadRequest();
        var smokesensorResources = smokesensors.Select(SmokeSensorResourceFromEntityAssembler.FromEntity);
        return Ok(smokesensorResources);
    }
    
    [HttpPost("create-smoke-sensor")]
    public async Task<IActionResult> CreateSmokeSensor([FromBody] CreateSmokeSensorResource resource)
    {
        try
        {
            var command = CreateSmokeSensorCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await smokesensorCommandService.Handle(command);

            return Ok("SmokeSensor created successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[CreateSmokeSensor] Argument error: {ex.Message}");
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
    
    [HttpPut("update-smoke-sensor-temperature")]
    public async Task<IActionResult> UpdateSmokeSensorTemperature([FromBody] UpdateSmokeSensorAnalogicValueResource resource)
    {
        var result = await smokesensorCommandService.Handle(
            UpdatSmokeSensorAnalogicValueCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpPut("update-smoke-sensor")]
    public async Task<IActionResult> UpdateSmokeSensor([FromBody] UpdateSmokeSensorResource resource)
    {
        var result = await smokesensorCommandService.Handle(
            UpdateSmokeSensorCommandFromResourceAssembler.ToCommandFromResource(resource));
        if (result is false)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    
}