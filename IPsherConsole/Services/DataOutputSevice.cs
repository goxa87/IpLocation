using IPsherConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPsherConsole.Services
{
    /// <summary>
    /// различные сервисы для вывода на консоль
    /// </summary>
    public static class DataOutputSevice
    {

        /// <summary>
        /// вывод списка IpData в в иде строк
        /// </summary>
        /// <param name="list">коллекция строк</param>
        public static void PrintListConsole(IEnumerable<IpData> list)
        {
            foreach (var e in list)
            {
                Console.WriteLine($"{e.IpDataId} - {e.Ip} - {e.Country} - {e.Sity} - {e.Latitude} - {e.Longitude}");
            }
        }
    }
}
