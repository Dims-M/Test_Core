using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.IO;

namespace ActionFilterSample.Infrastructure
{
    // Гибридный фильтр - одновременно фильтр действия и фильтр результата
    /// <summary>
    /// Гибридный фильтр Атрибут - одновременно фильтр действия и фильтр результата
    /// </summary>
    public class ProfileHybridAttribut : ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string message = $"Действие для {context.ActionDescriptor.DisplayName} = {timer.Elapsed}";

            StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            timer.Stop();
            string message = $"Результат для {context.ActionDescriptor.DisplayName} = {timer.Elapsed}";

            StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
