using Readline.Domain.Commons;
using Readline.Domain.Entites.Books;
using Readline.Domain.Entites.Cards;

namespace Readline.Domain.Entites.Orders;

public class CardItem : Auditable
{
    public long CardId {get;set; }
    public Card Card {get;set; }

    public long BookId {get; set;}
    public Book Book {get; set;}

    public int Count { get; set;}
    public decimal Price {get; set; }
    public decimal TotalPrice {get; set; }
}
