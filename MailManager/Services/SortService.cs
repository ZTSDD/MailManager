using MailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailManager.ViewModels;
using MailManager.Models;

namespace MailManager.Services
{
    public class SortService
    {
        public void ApplySorting(ref List<Mail> sourceList, SortViewModel sortVM)
        {
            // Пречисление MailListSortState содержит для каждого столбца по 2 типа сортировки, 
            // все четные значения - по возрастанию для каждого столбца.
            // Кейсами описывать много, прибегнул к магии
            bool isAscending = ((int)sortVM.Current % 2 == 0);
            int colId = (int)sortVM.Current / 2;
            if (isAscending)
            {
                sourceList = sourceList
                    .OrderBy(m => m.GetType()
                    .GetProperties()[colId]
                    .GetValue(m))
                    .ToList();
            }
            else
            {
                sourceList = sourceList
                    .OrderByDescending(m => m.GetType()
                    .GetProperties()[colId]
                    .GetValue(m))
                    .ToList();
            }
        }
    }
}
