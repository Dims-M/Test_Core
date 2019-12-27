using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ActionFilterSample.Infrastructure
{
    public class ProfileAsync : ActionFilterAttribute
    {
        private Stopwatch timer;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();

            // до вызова делегата ActionExecutionDelegate, код который запустится перед методом действия
            await next();
            // после вызова делегата ActionExecutionDelegate, код который запустится по завершению метода действия

            timer.Stop();
            string message = $"На выполнение метода {context.ActionDescriptor.DisplayName} затрачено {timer.Elapsed}";

            StreamWriter streamWriter = new StreamWriter("App_Data/log.txt", true);
            await streamWriter.WriteLineAsync(message);
            streamWriter.Close();
        }

    }
}
