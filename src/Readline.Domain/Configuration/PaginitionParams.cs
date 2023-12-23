namespace Readline.Domain.Configuration;

public class PaginitionParams
{
    private int pageSize;
    private int maxSize = 20;
    public int PageSize
    {
        get => pageSize == 0 ? 10 : pageSize;
        set { pageSize = value > maxSize ? maxSize : value; }
    }

    public int PageIndex { get; set; } = 1;
}
