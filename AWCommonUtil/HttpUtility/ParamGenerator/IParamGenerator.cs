using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil.HttpUtility.ParamGenerator
{
    interface IParamGenerator
    {
        string GetParamString(object data);
    }
}
