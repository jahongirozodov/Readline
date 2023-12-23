using Readline.Domain.Commons;
using Readline.Domain.Entites.Orders;
using Readline.Domain.Entites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readline.Domain.Entites.Cards;

public class Card : Auditable
{
    public long UserId {get;set; }
    public User User {get;set; }
    public decimal TotalPrice { get; set; }

    public ICollection<CardItem> Items {get;set; }
}
