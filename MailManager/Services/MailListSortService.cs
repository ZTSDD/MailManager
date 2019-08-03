using MailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.Services
{
    public class MailListSortService
    {
        public List<Mail> SortByColumnId(List<Mail> sourceList, MailListSortState sortState)
        {
            // Пречисление MailListSortState содержит для каждого столбца по 2 типа сортировки, 
            // все четные значения - по возрастанию для каждого столбца.
            // Кейсами описывать много, прибегнул к магии
            bool isAscending = ((int)sortState % 2 == 0);
            int colId = (int)sortState / 2;
            if (isAscending)
            {
                return sourceList
                    .OrderBy(m => m.GetType()
                    .GetProperties()[colId]
                    .GetValue(m))
                    .ToList();
            }
            else
            {
                return sourceList
                    .OrderByDescending(m => m.GetType()
                    .GetProperties()[colId]
                    .GetValue(m))
                    .ToList();
            }
        }
    }
}
