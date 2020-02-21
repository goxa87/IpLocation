using System;
using System.Collections.Generic;
using System.Text;

namespace IPsherConsole.Model
{
    /// <summary>
    /// модель геоданных
    /// </summary>
    public class IpData
    {
        /// <summary>
        ///  идентификатор
        /// </summary>
        public int IpDataId { get; set; }
        /// <summary>
        /// Ip адресс
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// страна
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// город
        /// </summary>
        public string Sity { get; set; }
        /// <summary>
        /// широта
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// долгота
        /// </summary>
        public string Longitude { get; set; }
    }
}
