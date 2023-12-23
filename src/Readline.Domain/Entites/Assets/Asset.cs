using Readline.Domain.Commons;
using System.IO.Enumeration;

namespace Readline.Domain.Entites.Assets;

public class Asset : Auditable
{
    public string FileName {get;set; }
    public string FilePath {get;set; }
}
