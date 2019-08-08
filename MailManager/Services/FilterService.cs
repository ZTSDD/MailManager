using MailManager.Models;
using MailManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MailManager.Services
{
    public class FilterService
    {
        public void ApplyFilters(ref IQueryable<Mail> mails, FilterViewModel filters)
        {
            int colId = 1;
            foreach (var filter in filters.GetType().GetProperties())
            {
                if (filter.GetValue(filters) != null && filter.GetValue(filters).ToString().Any())
                {
                    mails = ApplyFilter(mails, colId, filter.GetValue(filters).ToString());
                }
                colId++;
            }
        }

        private IQueryable<Mail> ApplyFilter(IQueryable<Mail> sourceList, int id, string filter)
        {
            return sourceList
                .Where(
                    m => (
                        CheckCondition(
                            m.GetType()
                                .GetProperties()[id]
                                .GetValue(m)
                                .ToString(),
                            filter
                        )
                    )
                );
        }

        private bool CheckCondition(string strValue, string filter)
        {
            // Если не выполняется условие, то возможно фильтр есть диапазон значений
            // Или значение совсем не прошло фильтр
            if (strValue.Contains(filter))
            {
                return true;
            }
            // Если не выполняется и это условие, то возможно фильтр есть числовое значение
            // Или значение совсем не прошло фильтр
            if (filter.Contains('-'))
            {
                string[] values = filter.Split('-');
                // Если не выполняется и это условие, то значение совсем не прошло фильтр
                if (values.Length == 2)
                {
                    // Фильтр есть диапазон значений
                    return ContainsValue(strValue, values[0], values[1]);
                }
                else
                {
                    //Значение совсем не прошло фильтр
                    return false;
                }
            }
            else
            {
                // Фильтр есть числовое значение
                return ContainsValue(strValue, filter);
            }
        }

        // Для проверки принадлежности интервалу
        private bool ContainsValue(string val, string beg, string end)
        {
            int begInterval;
            int endInterval;
            int value;
            if(int.TryParse(beg, out begInterval) && int.TryParse(end, out endInterval) && int.TryParse(val, out value))
            {
                return ((value >= begInterval) && (value <= endInterval));
            }
            return false;
        }

        // Для проверки равнозначности значений 
        private bool ContainsValue(string firstVal, string secondVal)
        {
            int first;
            int second;
            if (int.TryParse(firstVal, out first) && int.TryParse(secondVal, out second))
            {
                return first == second;
            }
            return false;
        }

    }
}
