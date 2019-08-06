using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailManager.Models;
using MailManager.ViewModels;

namespace MailManager.Services
{
    public class PaginationService
    {
        public void ApplyPagination(ref List<Mail> mailList, PaginationViewModel paginationVM)
        {
            mailList = mailList
                .Skip((paginationVM.CurrentPage - 1) * paginationVM.PageSize)
                .Take(paginationVM.PageSize)
                .ToList();
        }
    }
}
