using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    ///// <summary>
    ///// переопределение методо сервисв зависимости
    ///// </summary>
    //public  class ServiceProviderExtensions
    //{
    //    public  void AddTimeService(this IServiceCollection services)
    //    {
    //        services.AddTransient<TimeService>();
    //    }
    //}
    /// <summary>
    /// Определяем текущм время. 
    /// </summary>
    public  class TimeService
    {
        public static string GetTime() => System.DateTime.Now.ToString("hh:mm:ss"); //Поучаем время по текущей маске

        //
        
    }

}
