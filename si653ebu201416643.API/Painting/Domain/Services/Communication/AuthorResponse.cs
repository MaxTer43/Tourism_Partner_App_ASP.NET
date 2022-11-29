using si653ebu201416643.API.Painting.Domain.Models;
using si653ebu201416643.API.Shared.Domain.Services.Communication;

namespace si653ebu201416643.API.Painting.Domain.Services.Communication;

public class AuthorResponse : BaseResponse<Author>
{
    public AuthorResponse(Author resource) : base(resource)
    {
    }

    public AuthorResponse(string message) : base(message)
    {
    }
}