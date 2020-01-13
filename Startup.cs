using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test.Models; // пространство имен моделей
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework
using Test.Services;

namespace Test
{
    /// <summary>
    /// Класс с основными настройками.
    /// Отвечает за конфигурацию сервисов и middleaware
    /// </summary>
    public class Startup
    {

        //описание
       // https://metanit.com/sharp/aspnet5/2.2.php

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Этот метод вызывается средой выполнения. Используйте этот метод для добавления служб в контейнер.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            //Строка подключения к БД
            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connection2 = Configuration.GetConnectionString("DefaultConnection2");
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<DbConnection1Context>(options => options.UseSqlServer(connection2));

            services.AddControllersWithViews();

            //добавляем свой сервис с логированием
            services.AddScoped<Logger>();

        }

       // Этот метод вызывается средой выполнения.Используйте этот метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки на страницу
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // добавляем возможност работы со статическими файлами. стилями ccs html
            app.UseStaticFiles();

            // добавляем возможности маршрутизации
            app.UseRouting();

            // добавляем возможности авторизации
            app.UseAuthorization();

             

            // устанавливаем адреса, которые будут обрабатываться
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "TwoParametrRoute",
                   pattern: "{controller}/{action=Index}/{x}/{y}"
                   );

                endpoints.MapControllerRoute( //j
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
