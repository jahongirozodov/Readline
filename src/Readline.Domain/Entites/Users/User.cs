using Readline.Domain.Commons;
using Readline.Domain.Entites.Assets;
using Readline.Domain.Enums;
using System.Data;

namespace Readline.Domain.Entites.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public long? AssetId {get;set; }
    public Asset? Asset { get; set; }
}