using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MailManager.Models;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace MailManager.Services
{
    public class DbInitializerService
    {

        private string[] countries =
            {
            "Россия",
            "Беларусь",
            "Украина",
            "Казахстан",
            "Молдавия"
            };

        private string[] cities =
        {
            "Иннополис",
            "Димитровград",
            "Москва",
            "Сызрань",
            "Самара",
            "Воронеж",
            "Сочи",
            "Ульяновск",
            "Екатеринбург",
            "Бивис",
            "Волгоград",
            "Омск",
            "Черех",
            "Уфа",
            "Пермь",
            "Тюмень",
            "Тольятти",
            "Городок",
            "Краснодар",
            "Челябинск"
        };

        private string[] streets =
        {
            "пр-т Автостроителей",
            "пр-т Загитова",
            "ул. Гоголя",
            "ул. Гагарина",
            "ул. 50 лет октября",
            "ул. Парадизова",
            "ул. 1 Мая",
            "ул. Западный пригород",
            "пер. Пригородный",
            "ул. 1-я Бутурлиных",
            "пр-т Нарианова",
            "пр-т Строителей",
            "пр-т Водителей",
            "пр-т Лодочников",
            "ул. 1-я Линия",
            "ул. 8-я Линия",
            "ул. 9-я Линия",
            "ул. Интернационала",
            "ул. 4 Пятилетки",
            "пер. 19 Партсъезда",
        };

        private void initSomeRows(int countryId, int cityId, int streetId,
            int houses, int days, MailsContext context)
        {
            List<Mail> mails = new List<Mail>();
            for (int i = 0; i < houses; i++)
            {
                for (int j = days; j > 0; j--)
                {
                    mails.Add(new Mail()
                    {
                        Country = countries[countryId],
                        City = cities[cityId],
                        Street = streets[streetId],
                        HouseNumber = i,
                        MailIndex =
                        (countryId + 10) * 10000 +
                        (cityId + 10) * 100 +
                        (streetId + 10),
                        DateTime = DateTime.Now.AddDays(j)
                    });
                }
            }
            context.AddRange(mails);
            _ = context.SaveChanges();
        }

        public void Initialize(MailsContext context)
        {
            if (!context.Mails.Any())
            {
                bool tempAutoDetect = context.ChangeTracker.AutoDetectChangesEnabled;
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                for (int countryId = 0; countryId < countries.Length; countryId++)
                    for (int cityId = 0; cityId < cities.Length; cityId++)
                        for (int streetId = 0; streetId < streets.Length; streetId++)
                            initSomeRows(countryId, cityId, streetId, 125, 20, context);
                context.ChangeTracker.AutoDetectChangesEnabled = tempAutoDetect;
            }
        }
    }
}