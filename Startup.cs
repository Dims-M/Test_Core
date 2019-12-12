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

namespace Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ���������� ����� � ���������.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            //������ ����������� � ��
            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connection2 = Configuration.GetConnectionString("DefaultConnection2");
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<DbConnection1Context>(options => options.UseSqlServer(connection2));


            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���� ���������� � �������� ����������
            if (env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // ��������� ���������� ������ �� ������������ �������
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
