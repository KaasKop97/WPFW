using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week_14.Models;

namespace Week_14.ViewModels
{
    public class PagedList<T> : List<T>
    {
        public int Page { get; private set; }
        public int PageAmount { get; private set; }
        public PagedList(List<T> listPart, int totalAmount, int page, int perPage)
        {
            Page = page;
            PageAmount = (int)Math.Ceiling(totalAmount / (double)perPage);
            this.AddRange(listPart);
        }
        public bool HasPrevious() { return Page > 0; }
        public bool HasNext() { return Page < PageAmount - 1; }

        internal static IQueryable<Student> CreateAsync(object lijst, int page, int v)
        {
            throw new NotImplementedException();
        }
    }
    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> lijst, int page, int perPage)
    {
        return new PagedList<T>(
            await lijst.Skip(page * perPage).Take(perPage).ToListAsync(),
            await lijst.CountAsync(),
            page,
            perPage);
    }
}
