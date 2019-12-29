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

        /// <summary>
        /// Метод покупки телефона
        /// </summary>
        /// <param name="id">номер товара</param>
        /// <returns></returns>
        [HttpGet] // получение, чтение из БД
        public IActionResult Buy(int? id) // значение может быть  null
        {
            if (id == null) return RedirectToAction("Summary"); //если значения пустые. Возращаем гланую страницу
            ViewBag.PhoneId = id; // контейнер строк для передачи во вьюху Buy 
            return View(); 
        }

        /// <summary>
        /// метод для записи в таблицу БД  Buy
        /// </summary>
        /// <param name="order">обьект с данными типа класса Order</param>
        /// <returns></returns>
        [HttpPost] // отправка с браузера на запись
        public IActionResult Buy(Order order)
        {
            db.Orders.Add(order); //отпровляем в контекст для закрызки в БД
            // сохраняем в бд все изменения                                                                                                                        
            db.SaveChanges(); // команда принять и записать все изменения в БД 
            ViewBag.Text = order.User;
            //return "Спасибо, " + order.User + ", за покупку! Ваш заказ принят в обработку и будет доставлен в ближайшее время )))\t\n ";
            return RedirectToAction("PostBuy");
        }

        //Заглушка
        public IActionResult PostBuy()
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