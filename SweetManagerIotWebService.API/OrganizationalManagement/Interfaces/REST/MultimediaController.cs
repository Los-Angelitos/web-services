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
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class MultimediaController(IMultimediaCommandService multimediaCommandService, 
        IMultimediaQueryService multimediaQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMultimedia([FromBody] CreateMultimediaResource resource)
        {
            try
            {
                var multimediaCommand = CreateMultimediaCommandFromResourceAssembler.ToCommandFromResource(resource);

                var response = await multimediaCommandService.Handle(multimediaCommand);

                var responseResource = MultimediaResourceFromEntityAssembler.ToResourceFromEntity(response!);

                return StatusCode(StatusCodes.Status201Created, responseResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{multimediaId:int}")]
        public async Task<IActionResult> UpdateMultimedia(int multimediaId, [FromBody]UpdateMultimediaResource resource)
        {
            try
            {
                var multimediaCommand = UpdateMultimediaCommandFromResourceAssembler.ToCommandFromResource(resource);

                var response = await multimediaCommandService.Handle(multimediaCommand);

                var responseResource = MultimediaResourceFromEntityAssembler.ToResourceFromEntity(response!);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllDetails([FromQuery] int hotelId)
        {
            try
            {
                var multimedias = await multimediaQueryService.Handle(new GetAllDetailMultimediaByHotelIdQuery(hotelId));

                var multimediaResources = multimedias.Select(MultimediaResourceFromEntityAssembler.ToResourceFromEntity);

                return Ok(multimediaResources);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("main")]
        public async Task<IActionResult> GetMain([FromQuery] int hotelId)
        {
            try
            {
                var multimedia = await multimediaQueryService.Handle(new GetMainMultimediaByHotelIdQuery(hotelId));
                MultimediaResource multimediaResource;
                if (multimedia != null)
                {
                    multimediaResource = MultimediaResourceFromEntityAssembler.ToResourceFromEntity(multimedia);

                    return Ok(multimediaResource);
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
