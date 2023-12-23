using Readline.Domain.Commons;

namespace Readline.Domain.Entites.Categories;

public class Category : Auditable
{
    public string Name {get;set; }
    public string Description { get;set;}
}
