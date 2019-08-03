using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.ViewModels
{
    public class MailListFilterViewModel
    {
        public string CountryFilter { get; set; }
        public string CityFilter { get; set; }
        public string StreetFilter { get; set; }
        public string HouseNumberFilter { get; set; }
        public string MailIndexFilter { get; set; }
        public string DateTimeFilter { get; set; }
    }
}
