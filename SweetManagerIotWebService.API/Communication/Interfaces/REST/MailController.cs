using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using System.Net.Mime;

namespace SweetManagerIotWebService.API.Communication.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class MailController : ControllerBase
    {

    }
}
