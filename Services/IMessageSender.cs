using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    /// <summary>
    /// Интерфейс отправки сообщений. Будет использоватся как служба
    /// </summary>
   public interface IMessageSender
    {
        string Send();
    }
}
