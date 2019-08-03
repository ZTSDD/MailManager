using MailManager.Models;
using MailManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.Services
{
    // Пока не уверен, нужен ли данный класс, пока пусть тут
    public class MailListViewerService
    {
        private static int RowsPerPage = 10;

        public MailListViewModel CreateViewModel(List<Mail> mailList)
        {
            MailListViewModel viewModel = new MailListViewModel();
            viewModel.Mails = mailList;
            return viewModel;
        }
    }
}
