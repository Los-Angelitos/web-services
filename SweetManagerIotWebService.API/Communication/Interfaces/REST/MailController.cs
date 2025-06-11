using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.Communication.Domain.Services;
using SweetManagerIotWebService.API.Communication.Interfaces.REST.Resources;
using SweetManagerIotWebService.API.Communication.Interfaces.REST.Transform;
using SweetManagerIotWebService.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using System.Net.Mime;

namespace SweetManagerIotWebService.API.Communication.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class MailController(INotificationCommandService notificationCommandService) : ControllerBase
    {
        [HttpPost("admin-request")]
        public async Task<IActionResult> AdminRequestToOrganization([FromBody] CreateAdminRequestToOrganizationResource resource)
        {
            try
            {
                var createAdminRequest = CreateAdminRequestCommandFromResourceAssembler.ToCommandFromResource(resource);

                await notificationCommandService.Handle(createAdminRequest);

                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
