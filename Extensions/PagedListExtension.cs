using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using uow.Domain.Models;

namespace uow.Extensions
{
    public static class PagedListExtension
    {
        public async static Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> source, int page, int pageSize) where T : class
        {
            var totalRows = source.Count();
            var rows = await source
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<T>(rows, page, pageSize, totalRows);
        }
    }
}