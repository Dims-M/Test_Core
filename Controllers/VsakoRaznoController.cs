using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class VsakoRaznoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAlll()
        {
            // Чтение данных, которые передаются с помощью POST запроса в теле запроса.
            //  ViewBag.Text = Request.Form["message"];
            string vsako = Request.Form["message"];
           
            ViewBag.Text = vsako;
            return View(); // Вызываем нужную вьюху
        }

        public IActionResult Primer1()
        {
            //ViewBag.Text = Redirect.
            return Redirect("https://yandex.ru/"); // перенапровление на сайт
        }

        public IActionResult Primer2()
        {
            return Redirect("/Home/Calc"); // перенапровление на страницу с калькулятором
        }
    }
}