using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu201416643.API.Painting.Resources;

[SwaggerSchema(Required = new []{"First Name"})]
public class SaveAuthorResource
{
    [SwaggerSchema("Author First Name")]
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
}