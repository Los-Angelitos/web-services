using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Queries.RFID;
using SweetManagerIotWebService.API.Inventory.Domain.Services;
using SweetManagerIotWebService.API.Inventory.Interfaces.REST.Resources;
using SweetManagerIotWebService.API.Inventory.Interfaces.REST.Transform;

namespace SweetManagerIotWebService.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RfidCardController(
    IRfidCardCommandService rfidCardCommandService, 
    IRfidCardQueryService rfidCardQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRfidCard(CreateRfidCardResource resource)
    {
        var createRfidCardCommand = CreateRfidCardCommandFromResourceAssembler.ToCommandFromResource(resource);
        var rfidCard = await rfidCardCommandService.Handle(createRfidCardCommand);
        if (rfidCard is null) return BadRequest();
        var rfidCardResource = RfidCardResourceFromEntityAssembler.ToResourceFromEntity(rfidCard);
        return CreatedAtAction(nameof(GetRfidCardById), new { rfidCardId = rfidCardResource.Id }, rfidCardResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllRfidCards()
    {
        var getAllRfidCardsQuery = new GetAllRfidCardsQuery();
        var rfidCards = await rfidCardQueryService.Handle(getAllRfidCardsQuery);
        var rfidCardResources = rfidCards.Select(RfidCardResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(rfidCardResources);
    }
    
    [HttpGet("{rfidCardId:int}")]
    public async Task<IActionResult> GetRfidCardById(int rfidCardId)
    {
        var getRfidCardByIdQuery = new GetRfidCardByIdQuery(rfidCardId);
        var rfidCard = await rfidCardQueryService.Handle(getRfidCardByIdQuery);
        if (rfidCard == null) return NotFound();
        var rfidCardResource = RfidCardResourceFromEntityAssembler.ToResourceFromEntity(rfidCard);
        return Ok(rfidCardResource);
    }
    
    [HttpGet("hotel/{hotelId:int}")]
    public async Task<IActionResult> GetRfidCardsByHotelId(int hotelId)
    {
        var getRfidCardsByHotelIdQuery = new GetAllRfidCardsByHotelIdQuery(hotelId);
        var rfidCards = await rfidCardQueryService.Handle(getRfidCardsByHotelIdQuery);
        var rfidCardResources = rfidCards.Select(RfidCardResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(rfidCardResources);
    }
}