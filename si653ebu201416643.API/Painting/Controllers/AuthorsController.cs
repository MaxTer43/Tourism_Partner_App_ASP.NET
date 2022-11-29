using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si653ebu201416643.API.Painting.Domain.Models;
using si653ebu201416643.API.Painting.Domain.Services;
using si653ebu201416643.API.Painting.Resources;
using si653ebu201416643.API.Shared.Extensions;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu201416643.API.Painting.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;
    

    public AuthorsController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AuthorResource>), 200)]
    public async Task<IEnumerable<AuthorResource>> GetAllSync()
    {
        var authors = await _authorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);
        
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AuthorResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveAuthorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var author = _mapper.Map<SaveAuthorResource, Author>(resource);

        var result = await _authorService.SaveAsync(author);

        if (!result.Success)
            return BadRequest(result.Message);

        var authorResource = _mapper.Map<Author, AuthorResource>(result.Resource);

        return Created(nameof(PostAsync), authorResource);
    }
}