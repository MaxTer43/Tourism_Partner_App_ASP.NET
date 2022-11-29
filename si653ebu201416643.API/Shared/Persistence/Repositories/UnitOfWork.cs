using si653ebu201416643.API.Shared.Domain.Repositories;
using si653ebu201416643.API.Shared.Persistence.Contexts;

namespace si653ebu201416643.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}