using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AWCommonUtil.HttpUtility.ParamGenerator
{
    class FormGenerator : IParamGenerator
    {
        public string GetParamString(object data)
        {
            return GetUrlParameterString(data);
        }
        
        private static string GetUrlParameterString(object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            var paramDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
            StringBuilder sb = new StringBuilder();
            foreach (var p in paramDic)
            {
                sb.Append(string.Format("{0}={1}&", p.Key, p.Value));
            }
            return sb.ToString().Remove(sb.Length - 1);
        }
    }
}
