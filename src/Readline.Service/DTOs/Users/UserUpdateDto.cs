using Readline.Domain.Enums;

namespace Readline.Service.DTOs.Users;

public class UserUpdateDto
{
    public long Id {get;set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public long? AssetId {get;set; }
}
