using IPsherConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;
using IPGeolocation;

namespace IPsherConsole.GeoSevices
{
    /// <summary>
    /// Сервис определения геолокации на основе www.ipgeolocation.io
    /// </summary>
    class IpGeoIO : IGeolocationService
    {
        /// <summary>
        /// Эта штука собственно делает всю работу ))
        /// </summary>
        private readonly IPGeolocationAPI api;
        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="token">токен который получается на сайте.</param>
        public IpGeoIO(string token)
        {
            api = new IPGeolocationAPI(token);
        }
        /// <summary>
        /// Получение данных о геолокации и формирование IpData на основе IP 
        /// </summary>
        /// <param name="ip">входящее значение IP</param>
        /// <returns>IpData</returns>
        public IpData GetGeolocationData(string ip)
        {
            //параметры запроса
            GeolocationParams geoParams = new GeolocationParams();
            geoParams.SetIp(ip);
            geoParams.SetFields("geo,time_zone,currency");

            IpData rezult = new IpData();
            try
            {
                // получение данных
                Geolocation geolocation = api.GetGeolocation(geoParams);
                // формирование результата
                if (geolocation.GetStatus() == 200)
                {
                    rezult.Ip = ip;
                    rezult.Country = geolocation.GetCountryName();
                    rezult.Sity = geolocation.GetCity();
                    rezult.Latitude = geolocation.GetLatitude();
                    rezult.Longitude = geolocation.GetLongitude();
                }
                else throw new Exception("Неверный ответ сервера");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        
            return rezult;           
        }
    }
}
