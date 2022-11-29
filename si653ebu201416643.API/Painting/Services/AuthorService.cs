using si653ebu201416643.API.Painting.Domain.Models;
using si653ebu201416643.API.Painting.Domain.Repositories;
using si653ebu201416643.API.Painting.Domain.Services;
using si653ebu201416643.API.Painting.Domain.Services.Communication;
using si653ebu201416643.API.Shared.Domain.Repositories;

namespace si653ebu201416643.API.Painting.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Author>> ListAsync()
    {
        return await _authorRepository.ListAsync();
    }

    public async Task<AuthorResponse> SaveAsync(Author author)
    {
        try
        {
            await _authorRepository.AddAsync(author);
            await _unitOfWork.CompleteAsync();

            return new AuthorResponse(author);
        }
        catch (Exception e)
        {
            return new AuthorResponse($"An error occurred while saving the author: {e.Message}");
        }
    }

    public async Task<AuthorResponse> UpdateAsync(int id, Author author)
    {
        var existingAuthor = await _authorRepository.FindByIdAsync(id);

        if (existingAuthor == null)
            return new AuthorResponse("Author not found.");

        existingAuthor.FirstName = author.FirstName;

        try
        {
            _authorRepository.Update(existingAuthor);
            await _unitOfWork.CompleteAsync();

            return new AuthorResponse(existingAuthor);
        }
        catch (Exception e)
        {
            return new AuthorResponse($"An error occurred while updating the author: {e.Message}");
        }
    }

    public async Task<AuthorResponse> DeleteAsync(int id)
    {
        var existingAuthor = await _authorRepository.FindByIdAsync(id);

        if (existingAuthor == null)
            return new AuthorResponse("Author not found.");

        try
        {
            _authorRepository.Remove(existingAuthor);
            await _unitOfWork.CompleteAsync();

            return new AuthorResponse(existingAuthor);
        }
        catch (Exception e)
        {
            return new AuthorResponse($"An error occurred while deleting the author: {e.Message}");
        }
    }
}