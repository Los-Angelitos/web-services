using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProvidersController(IProviderCommandService providerCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddNewProvider(CreateProviderResource resource)
    {
        try
        {
            var createProviderCommand = CreateProviderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var provider = await providerCommandService.Handle(createProviderCommand);
            
            if (provider is null) return BadRequest();
            var providerResource = ProviderResourceFromEntityAssembler.ToResourceFromEntity(provider);
            return CreatedAtAction(nameof(GetProviderById), new {providerId = providerResource.Id}, providerResource);
        }catch(Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}