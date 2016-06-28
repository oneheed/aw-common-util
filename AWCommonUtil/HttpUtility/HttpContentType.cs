using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil
{
    /// <summary>
    /// 簡單類別-定義幾種Http的ContentType
    /// </summary>
    public class HttpContentType
    {
        private string type { get; set; }
        private HttpContentType(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// ContentType - application/json
        /// </summary>
        public static readonly HttpContentType Json = new HttpContentType("application/json");

        /// <summary>
        /// ContentType - application/x-www-form-urlencoded 
        /// </summary>
        public static readonly HttpContentType FormUrlEncode = new HttpContentType("application/x-www-form-urlencoded");

        /// <summary>
        /// ContentType - multipart/form-data
        /// </summary>
        public static readonly HttpContentType FormData = new HttpContentType("multipart/form-data");

        /// <summary>
        /// ContentType - text/xml; encoding='utf-8'
        /// </summary>
        public static readonly HttpContentType TextXml = new HttpContentType("text/xml; encoding='utf-8'");

        /// <summary>
        /// ContentType - application/xml
        /// </summary>
        public static readonly HttpContentType ApplicationXml = new HttpContentType("application/xml");

        /// <summary>
        /// Return Type's string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.type;
        }
    }
}
