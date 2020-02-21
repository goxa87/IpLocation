using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPsherConsole.Data;
using IPsherConsole.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPsherWebApi.Controllers
{
    /// <summary>
    /// API получения геоданных
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GeoIPController : ControllerBase
    {
        //датапровайдер
        private readonly IDataprovider _data;

        public GeoIPController(IDataprovider context)
        {
            _data = context;
        }

        /// <summary>
        /// Получение геоданных по IP
        /// </summary>
        /// <param name="ip">IP адрес</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetIpDataByIp/{ip}")]
        public IpData GetIpDataByIp(string ip)
        {
            return _data.GetIpDataByIp(ip);
        }

    }
}