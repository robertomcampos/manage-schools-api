using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services.Paging
{
    public static class PagingExtensions
    {
        public static async Task<PagedList<T>> PaginateAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var count = query.Count();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Items = items
            };
        }
    }
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
