using Readline.Domain.Entites.Books;
using Readline.Service.DTOs.Assets;

namespace Readline.Service.DTOs.Books;

public class BookResultDto
{
    public long Id {get;set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Pages { get; set; }
    public int PublicationYear { get; set; }
    public string Publisher { get; set; }
    public bool Availability { get; set; }

    public AssetResultDto Asset {get;set;}
    public Genre Genre { get; set; }
}
