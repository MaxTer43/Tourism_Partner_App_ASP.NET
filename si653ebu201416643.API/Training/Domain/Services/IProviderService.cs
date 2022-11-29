using si653ebu201416643.API.Training.Domain.Models;
using si653ebu201416643.API.Training.Domain.Services.Communication;

namespace si653ebu201416643.API.Training.Domain.Services;

public interface IProviderService
{
    Task<IEnumerable<Provider>> ListAsync();
    Task<ProviderResponse> SaveAsync(Provider provider);
}