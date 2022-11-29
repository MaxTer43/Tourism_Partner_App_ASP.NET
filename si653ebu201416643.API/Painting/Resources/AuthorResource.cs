using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu201416643.API.Painting.Resources;

public class AuthorResource
{
    [SwaggerSchema("Author Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Author First Name")]
    public string FirstName { get; set; }
    [SwaggerSchema("Author Last Name")]
    public string LastName { get; set; }
}