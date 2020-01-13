using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Test.Models;

namespace Test
{
    /// <summary>
    /// Класс отвественный за создание экземпляра IWebHost
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложения
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args). //создание строителя (Builder)
                Build().             //Построение HostBuilder созднание серевера(приложения)
                Run();               

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) //Scope, который может
        // используется для разрешения служб с ограниченной областью действия.
            {
                var services = scope.ServiceProvider;

                try
                {// соединение с бд
                    var context = services.GetRequiredService<MobileContext>(); //кака БД нужна
                    SampleData.Initialize(context);  //работа с Бд
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ошибка при иницализации DB.");
                }
            }
            host.Run(); // запуск
        }

        /// <summary>
        /// Метод создания и инициализации строителя  (Builder) для создания host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //Определения класса который будет отвественный зв наствройу сервера
                });
    }
}
