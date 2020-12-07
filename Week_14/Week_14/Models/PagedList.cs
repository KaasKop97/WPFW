using System;
usig System.Collections.Generic;

namespace Studenten.Models
{
	public class PagedList<T> : List<T>
	{
		public int Page { get; private set; }
		public int PageCount { get; private set; }
		
		public PagedList(List<> listPart, int totalCount, int page, int perPage)
		{ 
			Page = page;
			PageCount = (int)Math.Ceiling(totalCount/(double)perPage);
			this.AddRange(listPart);
		}

		public bool HasPrev() { return Page > 0; }
		public bool HasNext() { return Page < PageCount - 1;  }

		public static async Task<PagedList<T>> CreateAsync(IQueryable<T>, pageLijst, int page, int perPage)
		{
			return new PagedList<T>(
				await pageLijst.Skip(page * perPage).Take(perPage).ToListAsync(),
				await pageLijst.CountAsync(),
				page,
				perPage);
		}
	}
}