using System;
using static System.Console;
using IPGeolocation;
using IPsherConsole.Data;
using IPsherConsole.Services;
using IPsherConsole.GeoSevices;

namespace IPsherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //старт с меню
            Services.ConsoleMenu.Menu(new FakeDataProvider(5));
        }
    }
}
