using IPsherConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPsherConsole.Data
{
    /// <summary>
    /// Скелет для работы с данными
    /// </summary>
    public interface IDataprovider
    {
        /// <summary>
        /// получение всех записей
        /// </summary>
        /// <returns></returns>
        IEnumerable<IpData> GetIpDatas();
        /// <summary>
        /// получение записи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IpData GetIpData(int id);
        /// <summary>
        /// обновление записи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        void SetIpData(int id, IpData data);
        /// <summary>
        /// добавление записи
        /// </summary>
        /// <param name="data"></param>
        void AddData(IpData data);
        /// <summary>
        /// получение записи по IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public IpData GetIpDataByIp(string ip);
    }
}
