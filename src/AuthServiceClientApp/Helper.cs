using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    /// <summary>
    /// Just a helper class
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Shortcut for Encoding.UTF8.GetString(Convert.FromBase64String(base64)
        /// </summary>
        /// <param name="base64">A base64 encoded string</param>
        /// <returns>An decoded string</returns>
        public static string DecodeBase64String(string base64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
