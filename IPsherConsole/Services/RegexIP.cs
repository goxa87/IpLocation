using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IPsherConsole.Services
{
    public static class RegexIP
    {
        /// <summary>
        /// Проверяет строку на соответствие правилам IP
        /// </summary>
        /// <param name="ip">ip адрес</param>
        /// <returns>true - если введен коректно</returns>
        public static bool IpIsValid(string ip)
        {
            string pattern = @"^([0-9]{1,3}\.){3}[0-9]{1,3}$";

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(ip))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
