using MailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.ViewModels
{
    public class MailListViewModel
    {
        public List<Mail> Mails { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
    }
}
