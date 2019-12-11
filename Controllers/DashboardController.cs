using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    /// <summary>
    /// Основной контролер доски управления
    /// </summary>
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        
        //Основная панель
            public IActionResult Summary()
        {
            return View();
        }
    }
}