using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Models;


namespace Test.Controllers
{

    //подключение сущ баз данных
    //https://metanit.com/sharp/entityframeworkcore/1.3.php
    /// <summary>
    /// Основной контролер доски управления
    /// </summary>
    public class DashboardController : Controller
    {
        MobileContext db; // Обьект для связи с БД
        DbConnection1Context dbTable; // Обьект для связи с БД

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Конструктор по умолчанию. Таблица Phones
        /// </summary>
        /// <param name="context"></param>
        public DashboardController(MobileContext context)
        {

            db = context;

        }

        #region Примеры тесты
        ////Конструктор контролера. При передачи контекста. Обращается к БД  Временно отключим
        //public DashboardController(DbContext context)
        //{
        //    if (typeof(MobileContext).Equals(context))
        //    {
        //        db = (MobileContext)context;
        //    }
        //    dbTable = (DbConnection1Context)context; // is DbConnection1Context;
        //}

        ////Конструктор контролера. При передачи контекста. Обращается к БД 
        //public DashboardController(DbConnection1Context context)
        //{
        //   // dbTable = context;
        //}
        #endregion

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

        ///// <summary>
        ///// Получения списка всех товаров ихз БД
        ///// </summary>
        ///// <returns></returns>
        //public IActionResult GetTablesAlls()
        //{
        //    return View(dbTable.TablGoogles.ToList()); // получаем список всех строк из таблицы
        //}

    }
}