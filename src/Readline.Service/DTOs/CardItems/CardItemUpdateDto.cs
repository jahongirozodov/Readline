namespace Readline.Service.DTOs.CardItems;

public class CardItemUpdateDto
{
    public long CardId {get;set; }
    public long BookId {get; set;}
    public int Count { get; set;}
    public decimal Price {get; set; }
    public decimal TotalPrice {get; set; }
}
