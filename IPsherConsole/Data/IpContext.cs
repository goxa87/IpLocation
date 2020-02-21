using IPsherConsole.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPsherConsole.Data
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public class IpContext: DbContext
    {
        protected override void  OnConfiguring(DbContextOptionsBuilder options)
        {
            // !
            // Заменить эту строку подключения
            options.UseSqlServer(@"Data Source=GEORGIY-ПК\sqlexpress;Initial Catalog=IpGeo;Integrated Security=True;Pooling=False;");
        }
        /// <summary>
        /// набор геоданных
        /// </summary>
        public DbSet<IpData> IpDatas { get; set; }


    }
}
