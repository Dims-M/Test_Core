using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace ActionFilterSample.Infrastructure
{
    /// <summary>
    ///Вттрибут срабатывает при какой либо ошбике
    /// </summary>
    public class ExceptionLogingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            StreamWriter streamWriter = new StreamWriter("App_Data/logError.txt", true);

            // context.Exception - исключение, из-за которого сработал фильтр
            streamWriter.WriteLine("Message: " + context.Exception.Message);
            streamWriter.WriteLine("Stack Trace: " + context.Exception.StackTrace);
            streamWriter.WriteLine();

            streamWriter.Close();

            // возврат другого представления в случае ошибки
            context.Result = new ViewResult() { ViewName = "Error" };
        }
    }
}