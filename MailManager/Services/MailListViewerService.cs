using MailManager.Models;
using MailManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailManager.ViewModels;

namespace MailManager.Services
{
    // Пока не уверен, нужен ли данный класс, пока пусть тут
    public class MailListViewerService
    {
        public MailListViewModel CreateViewModel(List<Mail> mailList, FilterViewModel filterVM, MailListSortState sortState, int page, int pageSize = 10)
        {
            MailListViewModel mailListVM = new MailListViewModel();
            mailListVM.FilterViewModel = filterVM;
            new FilterService().ApplyFilters(ref mailList, filterVM);
            mailListVM.SortViewModel = new SortViewModel(sortState);
            new SortService().ApplySorting(ref mailList, mailListVM.SortViewModel);
            mailListVM.PaginationViewModel = new PaginationViewModel(mailList.Count, pageSize, page);
            new PaginationService().ApplyPagination(ref mailList, mailListVM.PaginationViewModel);
            mailListVM.Mails = mailList;
            return mailListVM;
        }
    }
}
