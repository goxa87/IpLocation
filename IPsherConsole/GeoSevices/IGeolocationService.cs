using IPsherConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPsherConsole.GeoSevices
{
    /// <summary>
    /// скелет обновления геодапнных
    /// </summary>
    interface IGeolocationService
    {
        IpData GetGeolocationData(string ip);
    }
}
