using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    //https://metanit.com/sharp/aspnet5/3.2.php
    /// <summary>
    /// Связь с базой данных
    ///  помогают получать из БД набор данных определенного типа (например, набор объектов Phone)
    /// </summary>
    public class MobileContext : DbContext
    {
        /// <summary>
        /// Кеш связь с таблицей БД Phones
        /// </summary>
        public DbSet<Phone> Phones { get; set; } // создание и связь с таблицей БД Phones
        public DbSet<Order> Orders { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
