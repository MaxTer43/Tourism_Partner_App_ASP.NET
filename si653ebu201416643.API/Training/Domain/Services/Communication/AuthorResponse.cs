using si653ebu201416643.API.Training.Domain.Models;
using si653ebu201416643.API.Shared.Domain.Services.Communication;

namespace si653ebu201416643.API.Training.Domain.Services.Communication;

public class ProviderResponse : BaseResponse<Provider>
{
    public ProviderResponse(Provider resource) : base(resource)
    {
    }

    public ProviderResponse(string message) : base(message)
    {
    }
}