using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform;
using System.Net.Mime;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class FogServerController(IFogServerCommandService fogServerCommandService, 
        IFogServerQueryService fogServerQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateFogServer([FromBody] CreateFogServerResource resource)
        {
            try
            {
                var createFogServerCommand = CreateFogServerCommandFromResourceAssembler.ToCommandFromResource(resource);

                var fogServer = await fogServerCommandService.Handle(createFogServerCommand);

                var fogServerResource = FogServerResourceFromEntityAssembler.ToResourceFromEntity(fogServer!);

                return StatusCode(StatusCodes.Status201Created, fogServerResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFogServerByHotelId([FromQuery] int hotelId)
        {
            try
            {
                var fogServer = await fogServerQueryService.Handle(new GetFogServerByHotelIdQuery(hotelId));

                if (fogServer is null)
                    return NotFound();

                var fogServerResource = FogServerResourceFromEntityAssembler.ToResourceFromEntity(fogServer);

                return Ok(fogServerResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFogServerById(int id)
        {
            try
            {
                var fogServer = await fogServerQueryService.Handle(new GetFogServerByIdQuery(id));

                if (fogServer is null)
                    return NotFound();

                var fogServerResource = FogServerResourceFromEntityAssembler.ToResourceFromEntity(fogServer);

                return Ok(fogServerResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
