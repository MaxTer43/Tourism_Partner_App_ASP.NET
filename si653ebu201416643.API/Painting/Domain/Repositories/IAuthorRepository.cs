using si653ebu201416643.API.Painting.Domain.Models;

namespace si653ebu201416643.API.Painting.Domain.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> ListAsync();
    Task AddAsync(Author author);
    Task<Author> FindByIdAsync(int id);
    void Update(Author author);
    void Remove(Author author);
}