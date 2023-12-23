using Readline.Domain.Commons;
using Readline.Domain.Entites.Assets;
using System.Reflection.Metadata.Ecma335;

namespace Readline.Domain.Entites.Books;

public class Book : Auditable
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Pages { get; set; }
    public int PublicationYear { get; set; }
    public string Publisher { get; set; }
    public bool Availability { get; set; }

    public long GenreId {get;set; }
    public Genre Genre { get; set; }

    public long? AssetId {get;set; }
    public Asset Asset { get; set; }    
}