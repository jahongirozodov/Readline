using Readline.Domain.Commons;
using Readline.Domain.Entites.Users;
using Readline.Domain.Enums;

namespace Readline.Domain.Entites.Orders;

public class Order : Auditable
{ 
    public long UserId {get;set; }
    public long PaymentId {get; set; }
    public Payment Payment {get;set; }    

    public decimal TotalAmount { get; set; }
    public bool IsSaved {get;set; }
    public OrderStatus OrderStatus {get;set; }
    public PaymentStatus PaymentStatus {get;set; }
    public PaymentType PaymentType {get; set; }

    public ICollection<OrderItem> Items {get;set; }
}
