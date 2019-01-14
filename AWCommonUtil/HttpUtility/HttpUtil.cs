using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AWCommonUtil.HttpUtility.ParamGenerator;
using Newtonsoft.Json;

namespace AWCommonUtil
{
    /// <summary>
    /// a wrapper function for http request
    /// </summary>
    public class HttpUtil
    {
        /// <summary>
        /// execute the http request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="type"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static string Execute(string url, object data, HttpMethod method, HttpContentType type, int timeOut)
        {
            switch (method)
            {
                case HttpMethod.GET:
                    return ExecuteRequest(url + "?" + ParamGeneratorFactory.GetParamGenerator(HttpContentType.FormData).GetParamString(data), type, null, method, timeOut);
                case HttpMethod.POST:
                case HttpMethod.DELETE:
                case HttpMethod.PUT:
                    return ExecuteRequest(url, type, data, method, timeOut);
                default:
                    throw new Exception("No such http method");
            }
        }
        /// <summary>
        /// execute the http request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Execute(string url, object data, HttpMethod method, HttpContentType type)
        {
            switch (method)
            {
                case HttpMethod.GET:
                    return ExecuteRequest(url + "?" + ParamGeneratorFactory.GetParamGenerator(HttpContentType.FormData).GetParamString(data), type, null, method);
                case HttpMethod.POST:
                case HttpMethod.DELETE:
                case HttpMethod.PUT:
                    return ExecuteRequest(url, type, data, method);
                default:
                    throw new Exception("No such http method");
            }
        }

        /// <summary>
        /// execute the http request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static WebResponse GetRespByExecute(string url, object data, HttpMethod method, HttpContentType type)
        {
            switch (method)
            {
                case HttpMethod.GET:
                    return GetRespByExecuteRequest(url + "?" + ParamGeneratorFactory.GetParamGenerator(HttpContentType.FormData).GetParamString(data), type, null, method);
                case HttpMethod.POST:
                case HttpMethod.DELETE:
                case HttpMethod.PUT:
                    return GetRespByExecuteRequest(url, type, data, method);
                default:
                    throw new Exception("No such http method");
            }
        }

        private static WebResponse GetRespByExecuteRequest(string url, HttpContentType type, object data, HttpMethod method)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.ContentType = type.ToString();
                req.Method = method.ToString();
                if (method != HttpMethod.GET)
                {
                    string strData = string.Empty;
                    strData = ParamGeneratorFactory.GetParamGenerator(type).GetParamString(data);

                    byte[] postBytes = Encoding.UTF8.GetBytes(strData);
                    req.ContentLength = postBytes.Length;
                    using (Stream reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(postBytes, 0, postBytes.Length);
                    }
                }

                return req.GetResponse();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string ExecuteRequest(string url, HttpContentType type, object data, HttpMethod method, int timeOut = 60)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.ContentType = type.ToString();
                req.Method = method.ToString();
                req.Timeout = timeOut;
                if (method != HttpMethod.GET)
                {
                    string strData = string.Empty;
                    strData = ParamGeneratorFactory.GetParamGenerator(type).GetParamString(data);

                    byte[] postBytes = Encoding.UTF8.GetBytes(strData);
                    req.ContentLength = postBytes.Length;
                    using (Stream reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(postBytes, 0, postBytes.Length);
                    }
                }

                using (WebResponse wr = req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
