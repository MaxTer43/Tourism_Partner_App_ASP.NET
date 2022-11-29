namespace si653ebu201416643.API.Painting.Domain.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public string PhotoUrl { get; set; }
    
    public int InitialSamples { get; set; }
    public int AuthorId { get; set; }
}