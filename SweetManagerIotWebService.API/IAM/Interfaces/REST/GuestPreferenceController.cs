using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Model.Queries.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Services.CommandServices.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Services.QueryServices.Preferences;
using SweetManagerIotWebService.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using SweetManagerIotWebService.API.IAM.Interfaces.REST.Resources.Preferences;
using SweetManagerIotWebService.API.IAM.Interfaces.REST.Transform.Preferences;
using System.Net.Mime;

namespace SweetManagerIotWebService.API.IAM.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    [Produces(MediaTypeNames.Application.Json)]
    public class GuestPreferenceController(IGuestPreferenceCommandService guestPreferenceCommandService, 
        IGuestPreferenceQueryService guestPreferenceQueryService) : ControllerBase
    {
        [Authorize]
        [HttpGet("{guestPreferenceId:int}")]
        public async Task<IActionResult> GetGuestPreferenceById(int guestPreferenceId)
        {
            try
            {
                var guestPreference = await guestPreferenceQueryService.Handle(new GetGuestPreferenceByIdQuery(guestPreferenceId));

                var guestPreferenceResource = GuestPreferenceResourceFromEntityAssembler.ToResourceFromEntity(guestPreference);

                return Ok(guestPreferenceResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("guests/{guestId:int}")]
        public async Task<IActionResult> GetGuestPreferenceByGuestId(int guestId)
        {
            try
            {
                var guestPreference = await guestPreferenceQueryService.Handle(new GetGuestPreferenceByGuestIdQuery(guestId));

                if (guestPreference is null)
                    return BadRequest("There is no preference for the given guest id");

                var guestPreferenceResource = GuestPreferenceResourceFromEntityAssembler.ToResourceFromEntity(guestPreference);
                 
                return Ok(guestPreferenceResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateGuestPreference([FromBody]CreateGuestPreferenceResource resource)
        {
            try
            {
                var guestPreferenceCommand = CreateGuestPreferenceCommandFromResourceAssembler.ToCommandFromResource(resource);

                var guestPreference = await guestPreferenceCommandService.Handle(guestPreferenceCommand);

                if (guestPreference is null)
                    return BadRequest("Couldn't create");

                var guestPreferenceResource = GuestPreferenceResourceFromEntityAssembler.ToResourceFromEntity(guestPreference);

                return StatusCode(StatusCodes.Status201Created, guestPreferenceResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{guestPreferenceId:int}")]
        public async Task<IActionResult> UpdateGuestPreference([FromBody]UpdateGuestPreferenceResource resource, int guestPreferenceId)
        {
            try
            {
                var updateGuestPreferenceCommand = UpdateGuestPreferenceCommandFromResourceAssembler.ToCommandFromResource(resource, guestPreferenceId);

                var guestPreference = await guestPreferenceCommandService.Handle(updateGuestPreferenceCommand);

                if (guestPreference is null)
                    return BadRequest("Couldn't update.");

                var guestPreferenceResource = GuestPreferenceResourceFromEntityAssembler.ToResourceFromEntity(guestPreference);

                return Ok(guestPreferenceResource);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
