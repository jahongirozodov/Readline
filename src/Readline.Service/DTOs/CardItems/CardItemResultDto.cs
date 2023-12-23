using Readline.Service.DTOs.Books;
using Readline.Service.DTOs.Cards;

namespace Readline.Service.DTOs.CardItems;

public class CardItemResultDto
{
    public CardResultDto Card {get;set; }
    public BookResultDto Book {get; set;}
    public int Count { get; set;}
    public decimal Price {get; set; }
    public decimal TotalPrice {get; set; }
}
