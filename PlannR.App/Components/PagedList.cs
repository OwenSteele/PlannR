using System;
using System.Collections.Generic;

namespace PlannR.App.Components
{
    public class PagedList<T>
    {

        public PagedList()
        {

        }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public List<T> Items { get; set; }

        public PagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Items = new List<T>();
            Items.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get => (PageIndex > 1);
        }

        public bool HasNextPage
        {
            get => (PageIndex < TotalPages);
        }
    }
}
