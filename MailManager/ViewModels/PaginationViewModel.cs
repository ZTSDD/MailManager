using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.ViewModels
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public bool HasNext { get { return CurrentPage < TotalPages; } }
        public bool HasPrev { get { return CurrentPage > 1; } }

        public PaginationViewModel(int listSize, int pageSize, int currentPage)
        {
            int maxPage = listSize / pageSize + 1;
            if (currentPage > maxPage)
            {
                currentPage = Math.Clamp(currentPage, 1, maxPage);
            }
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (listSize / pageSize + 1);
        }
    }
}
