using BitoDesktop.Domain.Configurations;
using System.Collections.Generic;
using System.Linq;

namespace BitoDesktop.Service.Helpers;

public static class CollectionExtensions
{
    public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
    {
        return @params.PageIndex > 0 && @params.PageSize >= 0
            ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : source;
    }
}