using System;
using System.Collections.Generic;

namespace Test
{
    // Add-Migration Initial первичная инициализация бд и миграция
    //Update-Database //обновление бд
    // Migration Update // обновление миграции
    public partial class TablGoogles
    {
        public int Id { get; set; }
        public string NameClienta { get; set; }
        public string PassClient { get; set; }
        public string TelefonClient { get; set; }
       public string DataTimeAddTable { get; set; }
    }
}
