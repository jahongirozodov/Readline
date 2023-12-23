namespace Readline.Service.DTOs.Genres;

public class GenreUpdateDto 
{
    public long Id { get;set;}
    public string Name {get;set; }
    public string Description {get;set; }
    
    public long CategoryId {get;set; }
}
