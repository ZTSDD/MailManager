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
        public MailListFilterViewModel FilterViewModel { get; set; }
    }
}
