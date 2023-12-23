using Readline.Service.DTOs.Categories;

namespace Readline.Service.DTOs.Genres;

public class GenreResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryResultDto Category {get;set; }
}
