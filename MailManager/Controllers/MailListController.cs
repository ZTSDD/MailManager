using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailManager.Models;
using MailManager.Services;
using MailManager.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailManager.Controllers
{
    public class MailListController : Controller
    {
        private MailListViewModel mailListViewModel;
        private List<Mail> mailList;

        public MailListController(MailsContext context)
        {
            mailList = context.Mails.ToList();
            this.mailListViewModel = (new MailListViewerService()).CreateViewModel(mailList); 
        }

        public ActionResult ShowMailList(MailListSortState sortState, MailListFilterViewModel filters)
        {
            mailListViewModel.Mails = (new MailListFilterService()).ApplyFilters(mailListViewModel.Mails, filters);
            mailListViewModel.Mails = (new MailListSortService()).SortByColumnId(mailListViewModel.Mails, sortState);
            mailListViewModel.SortViewModel = new SortViewModel(sortState);
            mailListViewModel.FilterViewModel = filters;
            return View("ShowMailList", mailListViewModel);
        }
    }
}