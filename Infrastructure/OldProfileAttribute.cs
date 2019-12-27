using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.IO;

namespace ActionFilterSample.Infrastructure
{
    /// <summary>
    /// Класс являющимся атрибутом. Отвечает за скорость вывполения работы контроллера
    /// </summary>
    public class OldProfileAsync : ActionFilterAttribute //имя атребута должно содержать ключевое слово Attribute и наследоватся от  ActionFilterAttribute
    {
        private Stopwatch timer; //переменная обьекта Stopwatch. Для замера производительности

        //Параметр ActionExecutingContext context содержит в себе инфомацию в каком контроллере или обьекте будет работать это свойство.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew(); // запуск замера производительности
        }

        //параметр context.ActionDescriptor.DisplayName - получаем имя конкретного контроллера
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop(); // остановка замера производительности
            string message = $"На выполнение метода {context.ActionDescriptor.DisplayName} затрачено {timer.Elapsed}";

            StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true); // запись в лог
            streamWriter.WriteLine(message); // вывод в консоль
            streamWriter.Close();
        }
    }
}
