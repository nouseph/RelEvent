using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class CatalogEventSeed
    {
        public static void Seed(CatalogEventContext catalogEventContext)
        {
            catalogEventContext.Database.Migrate();
            if (!catalogEventContext.CatalogEventCategories.Any())
            {
                catalogEventContext.CatalogEventCategories.AddRange(GetCatalogEventCategories());
                catalogEventContext.SaveChanges();

            }
            if (!catalogEventContext.CatalogEventTypes.Any())
            {
                catalogEventContext.CatalogEventTypes.AddRange(GetCatalogEventTypes());
                catalogEventContext.SaveChanges();
            }
            if (!catalogEventContext.CatalogEventItems.Any())
            {
                catalogEventContext.CatalogEventItems.AddRange(GetCatalogEventItems());
                catalogEventContext.SaveChanges();
            }

        }
        private static IEnumerable<CatalogEventCategory> GetCatalogEventCategories()
        {
            return new List<CatalogEventCategory>
            {
                new CatalogEventCategory
                {
                 Category="Music"
                 },
                new CatalogEventCategory
                {
                    Category="Tech"
                },
                new CatalogEventCategory
                {
                    Category="Food"
                },

                 new CatalogEventCategory
                {
                    Category="Fitness"
                },
                  new CatalogEventCategory
                {
                    Category="Kids"
                }

            };
        }

        private static IEnumerable<CatalogEventType> GetCatalogEventTypes()
        {
            return new List<CatalogEventType>
            {
                new CatalogEventType
                {
                 Type="Free"
                 },
                new CatalogEventType
                {
                  Type="Paid"
                },


            };
        }

        private static IEnumerable<CatalogEventItem> GetCatalogEventItems()
        {
            return new List<CatalogEventItem>()
            {
                new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 3,
                    Description = "Learn the art and science of mixing coffee drinks.All recipes are tested, using coffee as the main ingredient with a creative twist.",
                    Name = "Summer Coffee Drinks",Date=Convert.ToDateTime("1/8/2020 13:00 PM"),Location="Online",
                    Price = 10,EventHost="Geisha Coffee", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                 new CatalogEventItem { CatalogEventTypeId = 1, CatalogEventCategoryId = 3,
                    Description = "A Taste of African Heritage is a way of eating based on the healthy food traditions of people with African roots." +
                    "This healthy way of eating is powerfully nutritious and delicious, and naturally meets the guidelines experts recommend for supporting good health ",
                    Name = "A Taste of African Heritage",Date=Convert.ToDateTime("12/9/2020 14:00 PM"),Location="Redmond,WA",
                    Price = 0,EventHost="Culinary Literacy Centre", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },




                  new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 1,
                    Description = "Harry Styles fan organised concert.",
                    Name = "Harry Styles FINE LINE",Date=Convert.ToDateTime("7/10/2020 20:00 PM"),Location="Online",
                    Price = 200,EventHost="LiveLifeGreat", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },

                 new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 1,
                    Description = "Get ready to celebrate 1D's 10 year anniversary with singing, dancing and even crying.",
                    Name = "1D AFTER 10 YEARS CONCERT PARTY",Date=Convert.ToDateTime("12/9/2020 22:00 PM"),Location="Tacoma,WA",
                    Price = 100,EventHost="Concert Mode", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },


                  new CatalogEventItem { CatalogEventTypeId = 1, CatalogEventCategoryId = 2,
                    Description = "Youth in Tech is a skills training and employment program customized for youth 18-29 years of age.",
                    Name ="Youth in Tech Information Session",Date=Convert.ToDateTime("8/11/2020 10:00 AM"),Location="Online",
                    Price = 0,EventHost="Immigrant Services Society", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },

                 new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 2,
                    Description = "We plan to have a great panel of leaders and recruiters in tech as well as several members from the VetsinTech Employer" +
                    " Coalition which includes Facebook and Disney",
                    Name = "VetsinTech",Date=Convert.ToDateTime("12/9/2020 22:00 PM"),Location="Bellvue,WA",
                    Price = 15,EventHost="Concert Mode", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },

                 new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 5,
                    Description = "In this high energy 25-minute interactive dance class kids will learn Salsa, Mergengue," +
                    " and Bachata while dancing to classic and modern Latin music.",
                    Name ="Latin Dance Party for kids ",Date=Convert.ToDateTime("2/12/2020 10:00 AM"),Location="Online",
                    Price = 5,EventHost="Rae Choreography", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },

                 new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 5,
                    Description = "Looking for some holiday fun and awesome art activities for your budding art explorer's?" +
                    "Well look no further as The Chroma Kids has got you covered!!",
                    Name = "Junior & Tween Art Holiday Workshops",Date=Convert.ToDateTime("12/9/2020 11:00 AM"),Location="Bellvue,WA",
                    Price = 15,EventHost="Chroma Club", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },

                 new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 4,
                    Description = "Free Flo Fit Workouts is a 60 minute class that focuses on Compound Body movements paired with high intensity interval training (HIIT)." +
                    " Be prepared to burn a high volume of calories DURING and AFTER the session.",
                    Name ="Free Flo Fit Workouts",Date=Convert.ToDateTime("12/12/2020 10:00 AM"),Location="Online",
                    Price = 55,EventHost="Gold Gym", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },

                 new CatalogEventItem { CatalogEventTypeId = 2, CatalogEventCategoryId = 4,
                    Description = "Kick and Punch your way to fitness. Kick Box Cardio gets your heart pumping and helps you let out some aggression.",
                    Name = "Kick Box Cardio",Date=Convert.ToDateTime("12/11/2020 11:00 AM"),Location="Bellvue,WA",
                    Price = 35,EventHost=" Dulcinea Hellings", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },


            };
        }



    }
}
