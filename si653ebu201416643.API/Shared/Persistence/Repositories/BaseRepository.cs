using si653ebu201416643.API.Shared.Persistence.Contexts;

namespace si653ebu201416643.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}