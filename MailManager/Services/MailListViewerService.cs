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
        public MailListViewModel CreateViewModel(MailsContext context, FilterViewModel filterVM, MailListSortState sortState, int page, int pageSize = 10)
        {
            IQueryable<Mail> mails = context.Mails;
            MailListViewModel mailListVM = new MailListViewModel();
            mailListVM.FilterViewModel = filterVM;
            new FilterService().ApplyFilters(ref mails, filterVM);
            mailListVM.SortViewModel = new SortViewModel(sortState);
            new SortService().ApplySorting(ref mails, mailListVM.SortViewModel);
            mailListVM.PaginationViewModel = new PaginationViewModel(mails.Count(), pageSize, page);
            new PaginationService().ApplyPagination(ref mails, mailListVM.PaginationViewModel);
            mailListVM.Mails = mails.ToList();
            return mailListVM;
        }
    }
}
