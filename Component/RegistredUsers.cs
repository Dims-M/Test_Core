using AsyncComponents.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncComponents.Components
{
    
    /// <summary>
    /// Компонет длявьюх
    /// </summary>
    
    public class RegistredUsers : ViewComponent
    {
        private readonly UserService service;  //переменная для хранения промежудочных данных 

        //конструктор
        public RegistredUsers(UserService service)
        {
            this.service = service;
        }
        /// <summary>
        /// Асинхронный запрос к сайту. скачиваение с сервера Json
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<User> users = await service.GetUsersAsync();
            return View(users); // возвращаем лист
        }


    }
}
