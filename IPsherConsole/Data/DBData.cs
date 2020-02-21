using IPsherConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPsherConsole.Data
{
    public class DBData : IDataprovider
    {
        //контекст бд
        private readonly IpContext _context;
        /// <summary>
        /// инициализация
        /// </summary>
        public DBData()
        {
            _context = new IpContext();
        }
        /// <summary>
        /// Получение геоданных по id из БД
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>объект геоданных</returns>
        public IpData GetIpData(int id)
        {
            return _context.IpDatas.Where(e => e.IpDataId == id).FirstOrDefault();
        }
        /// <summary>
        /// возвращает IpData по IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public IpData GetIpDataByIp(string ip)
        {
            return _context.IpDatas.Where(e => e.Ip == ip).FirstOrDefault();
        }

        /// <summary>
        /// получение всех записей из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IpData> GetIpDatas()
        {
            return _context.IpDatas.ToList();
        }
        /// <summary>
        /// обновляет значения для данных по ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public void SetIpData(int id, IpData data)
        {
            
            var ipData = _context.IpDatas.Where(e => e.IpDataId == id).FirstOrDefault();
            if (ipData != null)
            {
                ipData.Country = data.Country;
                ipData.Sity = data.Sity;
                ipData.Latitude = data.Latitude;
                ipData.Longitude = data.Longitude;                
            }
            _context.SaveChanges();
        }
        /// <summary>
        /// Заполняет фейковыми данными
        /// </summary>
        /// <param name="n"></param>
        public void FillData(int n)
        {
           
            for (int i = 1; i <= n; i++)
            {
                _context.IpDatas.Add(new IpData
                {
                    Ip = $"{i}.1.1.1",
                    Country = $"no-data_{i}",
                    Sity = $"no-data_{i}",
                    Longitude = "",
                    Latitude = ""
                });
            }
            _context.SaveChanges();
        }
        /// <summary>
        /// Добавляет ноыую запись
        /// </summary>
        /// <param name="data"> объект геоданных IpData</param>
        public void AddData(IpData data)
        {
            _context.IpDatas.Add(data);
        }
    }
}
