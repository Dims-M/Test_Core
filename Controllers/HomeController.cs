using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
        [HttpPost]
        public IActionResult Registracion(RegistrationBindingModel model)
        {
            string[] sourse = { "Понедельник", "Втторник", "Среда", "Четверг", "Питница", "Суббота", "Воскрсенье", }; //Нужные данные. например из Базы данных
            SelectList selectListItems = new SelectList(sourse); // создаем специальны лист для выподающего списка
            ViewBag.SelectItems = selectListItems; //Создаем спец переменную ViewBag.SelectItems. В которой во вьюхе можно обращатсяпо имени


            if (string.IsNullOrEmpty(model.Login))
            {
                ModelState.AddModelError(nameof(model.Login), "Введите имя");
            }

            if (!string.IsNullOrEmpty(model.Login) && model.Login.Length > 50)
            {
                ModelState.AddModelError(nameof(model.Login), "Значение имени не может привышать 50 символов");
            }

            //if (string.IsNullOrEmpty(model. LastName))
            //{
            //    ModelState.AddModelError(nameof(model.LastName), "Введите фамилию");
            //}

            //if (!string.IsNullOrEmpty(model.LastName) && model.LastName.Length > 50)
            //{
            //    ModelState.AddModelError(nameof(model.LastName), "Значение фамилии не может привышать 50 символов");
            //}

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Введите Email");
            }

            if (!string.IsNullOrEmpty(model.Email) && !Regex.IsMatch(model.Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                ModelState.AddModelError(nameof(model.Email), "Не правильный формат Email");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError(nameof(model.Password), "Введите пароль");
            }

            if (string.IsNullOrEmpty(model.PasswordConfirm))
            {
                ModelState.AddModelError(nameof(model.PasswordConfirm), "Введите подтверждение пароля");
            }

            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError(nameof(model.Password), "Пароли не совпадают");
            }
            // Если модель прошла проверку и значения свойств соответствуют атрибутом установленным на модели,
            // то свойство ModelState.IsValid получает значение true
            if (ModelState.IsValid)
            {
                Debug.WriteLine($"В базу записан пользователь: {model.Login}  (email: {model.Email}, tel: {model.Phone})");
                return View("Success");
            }
            else
            {
                // если модель содержит значения противоречащие бизнес правилам - возвращаем то же самое представление с неправильными данными
                // для того, чтобы пользователь мог их поправить
                // return View(Registration(model)); // просто закрывается окно
                return View(model);
            }
            return View(); // 
        }
       
        // Метод действия, который запустится, когда пользователь сделает submit формы (отправит POST запрос на сервер).
        // При вызове данного метода, произойдет привязка модели, входящие данные в теле запроса, которые совпадают с названиями аргументов,
        // будут записаны в эти аргументы.
       
        public IActionResult Registracion()
        {
           
            return View();
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
