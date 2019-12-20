using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class JsonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Работа с 
        public IActionResult ClientInfo()
        {
            var client = new Client() //Класс опысывающего Клиента. Для передачи его в json формате
            {
                Id = 100,
                Login = "user1",
                Email = "user1@mail.ru"
            };

            return Json(client);
        }


        /// <summary>
        /// Класс описывающий клиента. для работы с json обьеками
        /// </summary>
        private class Client
        {
            public Client()
            {
            }

            public int Id { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
        }
    }
}