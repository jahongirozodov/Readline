using Readline.Service.DTOs.Users;

namespace Readline.Service.DTOs.Cards;

public class CardResultDto
{
    public UserResultDto User { get; set; }
    public decimal TotalPrice { get; set; }
}
