using si653ebu201416643.API.Training.Domain.Models;

namespace si653ebu201416643.API.Training.Domain.Repositories;

public interface IProviderRepository
{
    Task<IEnumerable<Provider>> ListAsync();
    Task AddAsync(Provider provider);
    Task<Provider> FindByIdAsync(int id);
    void Update(Provider provider);
    void Remove(Provider provider);
}