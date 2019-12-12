using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    /// <summary>
    /// Основной контролер доски управления
    /// </summary>
    public class DashboardController : Controller
    {
        MobileContext db; // Обьект для связи с БД

        public IActionResult Index()
        {
            return View();
        }

        //Конструктор контролера. При передачи контекста. Обращается к БД 
      public DashboardController(MobileContext context)
        {
            db = context; 
        }

        //Основная панель
        public IActionResult Summary()
        {
            return View();
        }

        /// <summary>
        /// Получения списка всех товаров ихз БД
        /// </summary>
        /// <returns></returns>
        public IActionResult GetGoodsAlls()
        {
            return View(db.Phones.ToList()); // получаем список всех товаров
        }

       
            public IActionResult Buy()
        {
            return View();
        }

    }
}