using Microsoft.AspNetCore.Mvc;

namespace ComponentViewResults.Components
{
    public class Component1 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Метод Content создает экземпляр класса ContentViewComponentResult, которые реализовывает интерфейс IViewComponentResult
            // Если метод возвращает тип данных string также используется экземпляр класса ContentViewComponentResult
            // Содержимое результата безопасно закодировано
            return Content("<b>Component1 (ContentViewComponentResult)</b>");
        }
    }
}
