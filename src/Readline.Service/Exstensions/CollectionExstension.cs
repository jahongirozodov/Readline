using Readline.Domain.Configuration;

namespace Readline.Service.Exstensions;

public static class CollectionExstension
{
    public static IQueryable<T> ToPaginate<T>(this IQueryable<T> values,PaginitionParams @params)
            => values.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
}
