namespace Readline.Service.DTOs.Orders;

public class OrderCreationDto
{
    public long CardId {get;set; }
    public long UserId {get;set; }
    public decimal TotalPrice {get;set; }
}
