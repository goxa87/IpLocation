using IPsherConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPsherConsole.Data
{
    /// <summary>
    /// поддельная БД
    /// </summary>
    public class FakeDataProvider : IDataprovider
    {
        /// <summary>
        /// источник на основе листа
        /// </summary>
        List<IpData> _data { get; set; }
        /// <summary>
        /// инициализация различными значениями
        /// </summary>
        /// <param name="n">количество новых элементов</param>
        public FakeDataProvider(int n)
        {
            _data = new List<IpData>(n);
            for (int i = 1; i <= n; i++)
            {
                _data.Add(new IpData
                {
                    IpDataId = i,
                    Ip = $"{i}.1.1.1",
                    Country = $"no-data_{i}",
                    Sity = $"no-data_{i}",
                    Longitude = "",
                    Latitude = ""
                });
            }
        }
        /// <summary>
        /// получение по id
        /// </summary>
        /// <param name="id">IpDataId в списке(ключ)</param>
        /// <returns></returns>
        public IpData GetIpData(int id)
        {
            return _data.Where(e => e.IpDataId == id).FirstOrDefault();
        }
        /// <summary>
        /// Возвращает всю коллекцию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IpData> GetIpDatas()
        {
            return _data;
        }
        /// <summary>
        /// Устанавливает новое значение
        /// </summary>
        /// <param name="id">id записи которую нужно изменить</param>
        /// <param name="newData">новое значение записи</param>
        public void SetIpData(int id, IpData newData)
        {
            foreach (var e in _data)
            {
                if (e.IpDataId == id)
                {
                    e.Country = newData.Country;
                    e.Sity = newData.Sity;
                    e.Latitude = newData.Latitude;
                    e.Longitude = newData.Longitude;
                    break;
                }
            }
            
        }
        /// <summary>
        /// Добавляет новый IP
        /// </summary>
        /// <param name="data"></param>
        public void AddData(IpData data)
        {
            _data.Add(data);
        }

        public IpData GetIpDataByIp(string ip)
        {
            return _data.Where(e => e.Ip == ip).FirstOrDefault();
        }
    }
}
