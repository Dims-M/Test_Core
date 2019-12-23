using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncComponents.Model
{
    /// <summary>
    /// класс для скасивания и конвертации Json файла с тестового севака
    /// </summary>
    public class UserService
    {
        private string url = "https://jsonplaceholder.typicode.com/users";

        /// <summary>
        /// Метод получение спарсенного  Json файла
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsersAsync()
        {
            HttpClient http = new HttpClient(); // для соединения и работы с сервером
            HttpResponseMessage response = await http.GetAsync(url); // запрос в серверу
           
            string content = await response.Content.ReadAsStringAsync();  //преоброзование в строку.
            return JsonConvert.DeserializeObject<List<User>>(content); //десиркализация строи в обьект <List<User>
        }
    }
}
