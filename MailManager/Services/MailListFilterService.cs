using MailManager.Models;
using MailManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MailManager.Services
{
    public class MailListFilterService
    {
        public List<Mail> ApplyFilters(List<Mail> mails, MailListFilterViewModel filters)
        {
            int colId = 1;
            foreach (var filter in filters.GetType().GetProperties())
            {
                if (filter.GetValue(filters) != null && filter.GetValue(filters).ToString().Any())
                {
                    // Вынести, как вернусь сюда
                    switch (filter.Name)
                    {
                        case "HouseNumberFilter":
                            {
                                mails = FilterByHouseNumber(mails, filter.GetValue(filters).ToString());
                            }
                            break;
                        default:
                            {
                                mails = FilterByColumnId(mails, colId, filter.GetValue(filters).ToString());
                            }
                            break;
                    }
                }
                colId++;
            }
            return mails;
        }

        private List<Mail> FilterByColumnId(List<Mail> sourceList, int id, string filter)
        {
            return sourceList
                .Where(
                    m => (
                        m.GetType()
                        .GetProperties()[id]
                        .GetValue(m)
                        .ToString()
                        .Contains(filter)
                    )
                )
                .ToList();
        }

        private List<Mail> FilterByHouseNumber(List<Mail> sourceList, string filter)
        {
            return sourceList
                .Where(
                    m => (
                        CheckCondition(
                        m.GetType()
                            .GetProperty("HouseNumber")
                            .GetValue(m)
                            .ToString(),
                        filter)
                    )
                )
                .ToList();
        }

        private bool CheckCondition(string strValue, string range)
        {
            if (range.Contains('-'))
            {
                string[] values = range.Split('-');
                if (values.Length == 2)
                {
                    return ContainsValue(strValue, values[0], values[1]);
                }
                else
                    return false;

            }
            else
            {
                return ContainsValue(strValue, range);
            }
        }

        // Для проверки принадлежности интервалу
        private bool ContainsValue(string val, string beg, string end)
        {
            int begInterval = 0;
            int endInterval = 0;
            int value = 0;
            if (int.TryParse(beg, out begInterval) &&
                                int.TryParse(end, out endInterval) &&
                                int.TryParse(val, out value))
            {
                return ((value >= begInterval) && (value <= endInterval));
            }
            return false;
        }

        // Для проверки равнозначности значений 
        private bool ContainsValue(string firstVal, string secondVal)
        {
            int first = 0;
            int second = 0;
            if (int.TryParse(firstVal, out first) && int.TryParse(secondVal, out second))
            {
                return first == second;
            }
            return false;
        }

    }
}
