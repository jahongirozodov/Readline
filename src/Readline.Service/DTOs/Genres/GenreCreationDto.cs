using Readline.Domain.Entites.Categories;

namespace Readline.Service.DTOs.Genres;

public class GenreCreationDto 
{
    public string Name {get;set; }
    public string Description {get;set; }
    
    public long CategoryId {get;set; }
}
