using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class UtmController : Controller
    {

        //Контроллер поумолчанию
        public IActionResult Index()
        {
            return View("Utm");
        }

        //Получение данных утм
        public IActionResult Utm()
        {
            int x1 = int.Parse(Request.Form["message"]);
            int y1 = int.Parse(Request.Form["message1"]);
           
            string result = $"Данные записаны в БД!! {Environment.NewLine} Инн{ x1 } PKI в системе егаис { y1}";
            ViewBag.Text = result; // отправляем во вьюху  для отображение рзультата Utm
            return View("Utm");
           
        }

    }
}