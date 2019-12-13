using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    public class SmsMessageSender : IMessageSender
    {
        /// <summary>
        /// Отправка соощеий по смс 
        /// </summary>
        /// <returns></returns>
        public string Send()
        {
            return "Отправка SMS";
        }

    }
}
