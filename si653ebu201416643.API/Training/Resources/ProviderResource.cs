using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu201416643.API.Training.Resources;

public class ProviderResource
{
    [SwaggerSchema("Provider Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Provider Name")]
    public string Name { get; set; }
    [SwaggerSchema("Provider Api Url")]
    public string ApiUrl { get; set; }
    [SwaggerSchema("Provider Key")]
    public string KeyRequired { get; set; }
    [SwaggerSchema("Provider Api Key")]
    public string ApiKey { get; set; }
}