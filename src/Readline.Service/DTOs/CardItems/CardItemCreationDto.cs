using Readline.Domain.Entites.Books;
using Readline.Domain.Entites.Cards;

namespace Readline.Service.DTOs.CardItems;

public class CardItemCreationDto
{
    public long CardId {get;set; }
    public long BookId {get; set;}
    public int Count { get; set;}
    public decimal Price {get; set; }
    public decimal TotalPrice {get; set; }
}
    