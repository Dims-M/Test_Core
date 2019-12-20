using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    /// <summary>
    /// Контроллер отвечает за работу с файлами
    /// </summary>
    public class FilesController : Controller
    {
        /// <summary>
        /// Предоставляет сведения о среде веб-хостинга, в которой выполняется приложение
        /// </summary>
        private readonly IWebHostEnvironment environment; //обьект инициализируется в конструкторе при запуске контроллера
      
        public FilesController(IWebHostEnvironment environment)
        {
            this.environment = environment; // получаем даные о текущем запущенном приложении
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SetFasilSample1()
        {// Часто испоьзуется когда данные храним в БД в масстве байтов
            byte[] fileContent = System.IO.File.ReadAllBytes("App_Data/docKKM.pdf"); // считываем нужный файл. 
            return File(fileContent, "application/pdf", "docKKM.pdf"); //отправляем массив в запрсе. Будет отправлен запрос еа скачивание файлов
        }

        public IActionResult SetFasilSampFileStreamle2()
        {// часто исполуется когда мы сами получили поток.и передаем его.
            FileStream fileStream = System.IO.File.OpenRead("App_Data/docKKM.pdf"); //Создаем поток. И отправленна на чттение файла. И открытие его в браузере

            return File(fileStream, "application/pdf");
        }

        //на основе физического файла на жест диске
        public IActionResult SetFasilPhysicalFileStreamle3()
        {
            return PhysicalFile(environment.ContentRootPath + @"\App_Data\docKKM.pdf", "application/pdf");
        }

    }
}