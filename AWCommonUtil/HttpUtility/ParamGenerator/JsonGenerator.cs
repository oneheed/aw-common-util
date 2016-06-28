using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AWCommonUtil.HttpUtility.ParamGenerator
{
    class JsonGenerator : IParamGenerator
    {
        public string GetParamString(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
