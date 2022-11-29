using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu201416643.API.Training.Resources;

[SwaggerSchema(Required = new []{"Name"})]
public class SaveProviderResource
{
    [SwaggerSchema("Provider Name")]
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
}