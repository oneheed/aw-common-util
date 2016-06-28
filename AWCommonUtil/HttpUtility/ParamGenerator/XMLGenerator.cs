using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil.HttpUtility.ParamGenerator
{
    class XMLGenerator : IParamGenerator
    {
        public string GetParamString(object data)
        {
            return data.ToString();
        }
    }
}
