namespace si653ebu201416643.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}