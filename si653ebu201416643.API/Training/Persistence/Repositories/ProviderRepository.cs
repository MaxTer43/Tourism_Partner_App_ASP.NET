using si653ebu201416643.API.Training.Domain.Models;
using si653ebu201416643.API.Training.Domain.Repositories;
using si653ebu201416643.API.Shared.Persistence.Contexts;
using si653ebu201416643.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace si653ebu201416643.API.Training.Persistence.Repositories;

public class ProviderRepository : BaseRepository, IProviderRepository
{
    public ProviderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Provider>> ListAsync()
    {
        return await _context.Providers.ToListAsync();
    }

    public async Task AddAsync(Provider provider)
    {
        await _context.Providers.AddAsync(provider);
    }

    public async Task<Provider> FindByIdAsync(int id)
    {
        return await _context.Providers.FindAsync(id);
    }

    public void Update(Provider provider)
    {
        _context.Providers.Update(provider);
    }

    public void Remove(Provider provider)
    {
        _context.Providers.Remove(provider);
    }
}