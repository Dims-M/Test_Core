using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test.Models; // ������������ ���� �������
using Microsoft.EntityFrameworkCore; // ������������ ���� EntityFramework
using Test.Services;

namespace Test
{
    /// <summary>
    /// ����� � ��������� �����������.
    /// �������� �� ������������ �������� � middleaware
    /// ����� ���������� ������ ����������
    /// ����� ������������ ��� ���������� ������ �������� � ��������� (Dependency-injection)
    /// </summary>
    public class Startup
    {
        // ���������� IWebHostEnvironment env �������� ���������� � ������� ������ ���������� ����� ���-��������, � ������� ����������� ����������
        //���������� IApplicationBuilder app - ���������� �����, ��������������� ��������� ��� ��������� ������� ����������

        // https://metanit.com/sharp/aspnet5/2.2.php

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

         //����������� ���� ����� ��� ���������� ����� � ���������.
        /// <summary>
        /// ����� ������������ ��� ���������� ������ �������� � ��������� (Dependency-injection)
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews(); //

            //������ ����������� � ��
            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connection2 = Configuration.GetConnectionString("DefaultConnection2");
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<DbConnection1Context>(options => options.UseSqlServer(connection2));

            services.AddControllersWithViews();

            //��������� ���� ������ � ������������
            services.AddScoped<Logger>();

        }


        //����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        /// <summary>
        ///���� ����� ��� ��������� ��������� HTTP-��������. 
        ///�������� Middleware( ���� �������) - ��� ���� ������������ ����, ������� �������� ������ �������� � ��������� ��������� HTTP ������� � ������
        /// Middleware - �����*
        /// *���������� ����� �� ���������� ������ ��������� Middleware � ��������.
        /// *�����  ��������� ������ �� � ����� ��������� Middleware ������� ��������� � ��������.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���� ���������� � �������� ����������
            if (env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������ �� ��������
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); //������� �������� � �������
            }

            // ��������� ���������� ������ �� ������������ �������. ������� ccs html
            app.UseStaticFiles();

            // ��������� ����������� �������������
            app.UseRouting();

            // ��������� ����������� �����������
            app.UseAuthorization();

             

            // ������������� ������, ������� ����� ��������������
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
