using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.Infrastructure.TagHelpers
{
    // Дескрипторный вспомогательный класс представлен классом производным от TagHelper
    // Имя класса определяет для каких HTML элементов данный класс будет работать
    // ButtonTagHelper будет обслуживать все элементы <button>
    /// <summary>
    /// Дескрипторный вспомогательный класс для работы с HTML элементов. Самописный.
    /// </summary>
    public class ButtonTagHelper : TagHelper
    {
        // Свойство класса будет инициализироваться значениями атрибута HTML элемента, для которого этот класс был создан.
        // Если атрибут с именем my-button-color не будет найден на элементе, свойству будет присвоено значение null
        public string MyButtonColor { get; set; }


        // Метод определяет какие манипуляции будут проведены над HTML элементом, для которого добавлен TagHelper
        /// <summary>
        /// Метод определяет какие манипуляции будут проведены над HTML элементом, для которого добавлен TagHelper
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Альтернативный способ получения доступа, к HTML разметке элемента
            var color = context.AllAttributes["my-button-color"]?.Value;

            output.Attributes.SetAttribute("class", $"my-btn my-btn-{MyButtonColor}");
        }
    }
}