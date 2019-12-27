using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionFilterSample.Infrastructure;
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
        [OldProfileAsync] //атрибут для замера производительности клнтрлддера
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
        /// <returns>Возращает список все данных из листа</returns>
       //[OldProfileAsync] //атрибут для замера производительности кjнтрлддера, Асинхронная версия
       // [ResultProfile] //атрибут для замера производительности кjнтрлддера, Будет запускатсяв момент запуска метода в контроллере
        [ProfileHybridAttribut] //атрибут для замера производительности кjнтрлддера, Будет запускатсяв момент запуска метода в контроллере
        [ExceptionLoging] // атрибут для  отлова ошибок.Фильт срабатывает Срабатывает при ошибках
        public IActionResult GetTablesAlls()
        {
            //искустеввно вызывае ошибку
            throw new SystemException("Искуственная ошибка");
            return View(dbTable.TablGoogles.ToList()); // получаем список всех строк из таблицы
        }

    }
}