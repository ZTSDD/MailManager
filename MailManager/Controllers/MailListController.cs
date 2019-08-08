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
        private readonly MailsContext context;

        public MailListController(MailsContext context)
        {
            this.context = context;
        }

        public ActionResult ShowMailList(MailListSortState sortState, FilterViewModel filterVM, int page = 1)
        {
            Task<MailListViewModel> mailListViewModel = CreateViewModelAsync(sortState, filterVM, page);
                //new MailListViewerService().CreateViewModel(context, filterVM, sortState, page)
            return View("ShowMailList", mailListViewModel.Result);
        }

        private async Task<MailListViewModel> CreateViewModelAsync(MailListSortState sortState, FilterViewModel filterVM, int page = 1)
        {
            return await Task.Run( 
                () => 
                    new MailListViewerService()
                        .CreateViewModel(context, filterVM, sortState, page));
        }

    }
}