using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    public class EmailMessageSender : IMessageSender
    {
        /// <summary>
        /// Отправка емайл сообщений
        /// </summary>
        /// <returns></returns>
        public string Send()
        {
            return "Отправка Емайла";
        }

    }
}
