using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models; //связь с БДы

namespace Test
{
    /// <summary>
    /// Тестовой класс. Который заполняет бд
    /// </summary>
    public static class SampleData
    {

         public static void Initialize(MobileContext context)
       // public static void Initialize(IServiceProvider serviceProvider)
        {
           // var context = serviceProvider.GetService(typeof(MobileContext)) as MobileContext;

            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    }
                );
                context.SaveChanges(); //сохраняем БД
            }
        }

    }
}
