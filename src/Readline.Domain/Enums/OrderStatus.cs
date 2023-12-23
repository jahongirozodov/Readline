using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readline.Domain.Enums;
public enum OrderStatus
{
    Checkout,
    Pending,
    Process,
    Shipping,
    Shipped,
    Cancelled
}