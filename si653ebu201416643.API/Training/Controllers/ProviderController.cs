using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si653ebu201416643.API.Training.Domain.Models;
using si653ebu201416643.API.Training.Domain.Services;
using si653ebu201416643.API.Training.Resources;
using si653ebu201416643.API.Shared.Extensions;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu201416643.API.Training.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Providers")]
public class ProvidersController : ControllerBase
{
    private readonly IProviderService _providerService;
    private readonly IMapper _mapper;
    

    public ProvidersController(IProviderService providerService, IMapper mapper)
    {
        _providerService = providerService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProviderResource>), 200)]
    public async Task<IEnumerable<ProviderResource>> GetAllSync()
    {
        var providers = await _providerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderResource>>(providers);
        
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProviderResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveProviderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var provider = _mapper.Map<SaveProviderResource, Provider>(resource);

        var result = await _providerService.SaveAsync(provider);

        if (!result.Success)
            return BadRequest(result.Message);

        var providerResource = _mapper.Map<Provider, ProviderResource>(result.Resource);

        return Created(nameof(PostAsync), providerResource);
    }
}