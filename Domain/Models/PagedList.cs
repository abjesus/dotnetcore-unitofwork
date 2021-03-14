using System;
using System.Collections.Generic;

namespace uow.Domain.Models
{
    public class PagedList<T> : List<T>
    {
        public int Page { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        public PagedList(List<T> rows, int page, int pageSize, int totalRows)
        {
            Page = page;
            PageSize = pageSize;
            TotalRows = totalRows;
            TotalPages = (int)Math.Ceiling(totalRows/(double)pageSize);
            AddRange(rows);
        }

        public PagedList() {}
    }
}