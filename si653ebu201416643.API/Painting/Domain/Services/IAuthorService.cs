using si653ebu201416643.API.Painting.Domain.Models;
using si653ebu201416643.API.Painting.Domain.Services.Communication;

namespace si653ebu201416643.API.Painting.Domain.Services;

public interface IAuthorService
{
    Task<IEnumerable<Author>> ListAsync();
    Task<AuthorResponse> SaveAsync(Author author);
}