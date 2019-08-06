using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MailManager.Models;

namespace MailManager.Services
{
    public class DbInitializerService
    {
        private const int citiesPerCountry = 2;

        private string[] countries =
            {
            "Россия",
            "Беларусь",
            "Украина",
            };

        private string[] cities =
        {
            "Ульяновск",
            "Димитровград",
            "Минск",
            "Могилёв",
            "Херсон",
            "Киев",
        };

        private int[,] mailIndexes = new int[,]
        {
            { 432098, 432122, 432256 },
            { 433502, 433512, 433012 },
            { 220015, 220036, 220048 },
            { 212016, 212032, 212064 },
            { 701006, 701013, 701028 },
            { 120220, 120285, 1203104 },
        };

        private string[] streets =
        {
            "пр-т Автостроителей",
            "пр-т Загитова",
            "ул. Гоголя",
            "ул. Гагарина",
            "ул. 50 лет октября",
            "ул. Парадизова",
        };

        // Не забыть узнать почему он создает их не по порядку
        public void Initialize(MailsContext context)
        {
            if (!context.Mails.Any())
            {
                Random random = new Random();
                for (int countryID = 0; countryID < countries.Length; countryID++)
                {
                    for (int cityId = countryID * citiesPerCountry; cityId < (countryID * citiesPerCountry + citiesPerCountry); cityId++)
                    {
                        for (int streetId = 0; streetId < streets.Length; streetId++)
                        {
                            context.Mails.Add(new Mail()
                            {
                                Country = countries[countryID],
                                City = cities[cityId],
                                Street = streets[streetId],
                                HouseNumber = random.Next(1, 100),
                                MailIndex = mailIndexes[cityId, random.Next(0,3)],
                                DateTime = DateTime.Now
                            });;
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
