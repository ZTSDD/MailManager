using MailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.ViewModels
{
    public class SortViewModel
    {
        public MailListSortState IdSort { get; set; }
        public MailListSortState CountrySort { get; set; }
        public MailListSortState CitySort { get; set; }
        public MailListSortState StreetSort { get; set; }
        public MailListSortState HouseNumberSort { get; set; }
        public MailListSortState MailIndexSort { get; set; }
        public MailListSortState DateTimeSort { get; set; }
        public MailListSortState Current { get; private set; }

        public SortViewModel(MailListSortState sortOrder)
        {
            IdSort = sortOrder == MailListSortState.Id_A ? MailListSortState.Id_D : MailListSortState.Id_A;
            CountrySort = sortOrder == MailListSortState.Country_A ? MailListSortState.Country_D : MailListSortState.Country_A;
            CitySort = sortOrder == MailListSortState.City_A ? MailListSortState.City_D : MailListSortState.City_A;
            StreetSort = sortOrder == MailListSortState.Street_A ? MailListSortState.Street_D : MailListSortState.Street_A;
            HouseNumberSort = sortOrder == MailListSortState.HouseNumber_A ? MailListSortState.HouseNumber_D : MailListSortState.HouseNumber_A;
            MailIndexSort = sortOrder == MailListSortState.MailIndex_A ? MailListSortState.MailIndex_D : MailListSortState.MailIndex_A;
            DateTimeSort = sortOrder == MailListSortState.DateTime_A ? MailListSortState.DateTime_D : MailListSortState.DateTime_A;
            Current = sortOrder;
        }
    }
}
