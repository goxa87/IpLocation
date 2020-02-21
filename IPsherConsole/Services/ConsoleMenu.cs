using IPsherConsole.Data;
using static System.Console;  
using System;
using System.Collections.Generic;
using System.Text;
using IPsherConsole.GeoSevices;
using System.Text.RegularExpressions;

namespace IPsherConsole.Services
{
    /// <summary>
    /// менюшка для консоли
    /// </summary>
    public static class ConsoleMenu
    {
        /// <summary>
        /// меню
        /// </summary>
        /// <param name="data">датапровайдер</param>
        public static void Menu(IDataprovider data)
        {
            IDataprovider _data = data;
            // флаг выхода из программы
            bool continueMenu = true;
            while (continueMenu)
            {
                WriteLine("Выбирите действие:\n1-Показать данные\n2-обновить БД;\n3-Добавить IP\n4-найти по IP\n0-ВЫЙТИ");
                switch (ReadLine())
                {
                    //показать таблицу данных 
                    case "1":
                        {
                            DataOutputSevice.PrintListConsole(_data.GetIpDatas());
                            break;
                        }
                    // обновить все данные в базе
                    case "2":
                        {
                            IpGeoIO geo = new IpGeoIO("48a6263b98024f0492df2d06eb8333d4");
                            var IpList = _data.GetIpDatas();
                            foreach (var e in IpList)
                            {
                                _data.SetIpData(e.IpDataId, geo.GetGeolocationData(e.Ip));
                            }
                            WriteLine("Успешно.");
                            break;
                        }
                    // добавить новый ip
                    case "3":
                        {
                            WriteLine("Введите адрес IP:");
                            string ip = ReadLine();
                            // проверка на валидность данных
                            if (RegexIP.IpIsValid(ip))
                            {
                                try
                                {
                                    // получение геоданных
                                    IpGeoIO geo = new IpGeoIO("48a6263b98024f0492df2d06eb8333d4");
                                    var geoData = geo.GetGeolocationData(ip);
                                    //обновление бд
                                    _data.AddData(geoData);
                                    WriteLine("Успешно");
                                }
                                catch (Exception ex)
                                {
                                    WriteLine(ex.Message);
                                }
                                break;
                            }
                            else {
                                WriteLine("Введенный IP не соответствует формату");
                            }
                            break;
                        }
                    //найти по IP
                    case "4":
                        {
                            WriteLine("Введите IP:");
                            var ip = _data.GetIpDataByIp(ReadLine());
                            WriteLine($"{ip.Ip} - {ip.Latitude} - {ip.Longitude} - {ip.Country} - {ip.Sity}");
                            break;
                        }
                    // выйти
                    case "0":
                        continueMenu = false;
                        break;
                    default:
                        {
                            WriteLine("Некоректное значение. Попробуйте еще раз");
                            break;
                        }
                }
            }            
        }
    }
}
