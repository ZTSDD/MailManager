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
        private readonly List<Mail> mailList;

        public MailListController(MailsContext context)
        {
            mailList = context.Mails.ToList();
        }

        public ActionResult ShowMailList(MailListSortState sortState, FilterViewModel filterVM, int page = 1)
        {
            MailListViewModel mailListViewModel = new MailListViewerService().CreateViewModel(mailList, filterVM, sortState, page);
            return View("ShowMailList", mailListViewModel);
        }
    }
}