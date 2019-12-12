using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    /// <summary>
    /// Контоллер для связи с БД гугл таблиц
    /// </summary>
    public class TableGoogleInfoController : Controller
    {
        DbConnection1Context dbTable; // Обьект для связи с БД

        public IActionResult Index()
        {
            return View();
        }


        //Конструктор контролера. При передачи контекста. Обращается к БД 
        public TableGoogleInfoController(DbConnection1Context context)
        {
            dbTable = context; // при создании или заходе на этот контроллер создается подключение к бд
        }

        /// <summary>
        /// Получения списка всех товаров ихз БД
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTablesAlls()
        {
            return View(dbTable.TablGoogles.ToList()); // получаем список всех строк из таблицы
        }

    }
}