using Readline.Domain.Entites.Books;

namespace Readline.Domain.Entites.Orders;

public class OrderItem
{
    public long OrderId { get;set;}
    public Order Order { get;set;}

    public long BookId {get;set;}
    public Book Book {get;set;}

    public decimal Price { get; set; }
    public int Amount { get; set; }
}
