using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using DisplayAttributeSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Контроллер поумолчанию
        public IActionResult Index()
        {
            //string[] sourse = { "Понедельник", "Втторник", "Среда", "Четверг", "Питница", "Суббота", "Воскрсенье", };
            //SelectList selectListItems = new SelectList(sourse); // создаем специальны лист для выподающего списка
            //ViewBag.SelectItems = selectListItems; //Создаем спец переменную ViewBag.SelectItems. В которой во вьюхе можно обращатсяпо имени

            return View();
           // return Redirect("~/Home/Registracion");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Контролер срабатывающий при регистраци. Откроется вьюха с формами регистрации
        public IActionResult Registracion()
        {
            string[] sourse = { "Понедельник", "Втторник", "Среда", "Четверг", "Питница", "Суббота", "Воскрсенье", };
            SelectList selectListItems = new SelectList(sourse); // создаем специальны лист для выподающего списка
            ViewBag.SelectItems = selectListItems; //Создаем спец переменную ViewBag.SelectItems. В которой во вьюхе можно обращатсяпо имени

            return View(); // 
        }
       
        // Метод действия, который запустится, когда пользователь сделает submit формы (отправит POST запрос на сервер).
        // При вызове данного метода, произойдет привязка модели, входящие данные в теле запроса, которые совпадают с названиями аргументов,
        // будут записаны в эти аргументы.
        [HttpPost]
        public IActionResult Registration(RegistrationBindingModel model, string selectListItems)
        {
            // Обработка полученных данных

            Debug.WriteLine("Selected - " + selectListItems);

            //Debug.WriteLine("First Name = " + firstName);
            //Debug.WriteLine("Last Name = " + lastName);
            //Debug.WriteLine("Email = " + email);
            //Debug.WriteLine("Phone Number = " + phoneNumber);
            Debug.WriteLine(model.Login);
            Debug.WriteLine(model.Email);
            Debug.WriteLine(model.Password);
            Debug.WriteLine(model.PasswordConfirm);
            Debug.WriteLine(model.TermsAccepted);

            return View("Success", selectListItems); //во вьюхе серез модель будет отображатся выбранный день недели
           // return View();
        }

        public IActionResult GetPci()
        {
            return View("GetPci");
        }

        /// <summary>
        /// Переодрисация с главной страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAlll()
        {
            return View("GetAlll");
        }

        public IActionResult Primer1()
        {
            return Redirect("https://yandex.ru/");
        }

        // /home/Calc
        public IActionResult Calc(int x, int y)
        {
            int result = x + y;
            ViewBag.Text = result;
            return View();
        }
        // /home/Create
        [HttpPost]
        public IActionResult Create(int x, int y)
        {
            int result = x + y;
            ViewBag.Text = result;
            return View();
        }

        public IActionResult CalcString (string id)
        {
            return View("Ваш номер ="+ id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
