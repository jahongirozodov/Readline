using Readline.Domain.Commons;
using Readline.Domain.Entites.Categories;

namespace Readline.Domain.Entites.Books;

public class Genre : Auditable
{
    public string Name {get;set; }
    public string Description {get;set; }
    
    public long CategoryId {get;set; }
    public Category Category {get;set; }
}
