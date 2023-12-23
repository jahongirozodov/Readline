using Readline.Domain.Enums;
using Readline.Service.DTOs.Assets;

namespace Readline.Service.DTOs.Users;

public class UserResultDto
{
    public long Id {get;set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    public AssetResultDto Asset {get;set; }
}
