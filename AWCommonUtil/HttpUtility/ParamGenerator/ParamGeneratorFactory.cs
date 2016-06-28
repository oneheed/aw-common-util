using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil.HttpUtility.ParamGenerator
{
    class ParamGeneratorFactory
    {
        public static IParamGenerator GetParamGenerator(HttpContentType type)
        {
            var typeStr = type.ToString();
            if (typeStr == HttpContentType.TextXml.ToString() ||
                typeStr == HttpContentType.ApplicationXml.ToString())
            {
                return new XMLGenerator();
            }
            else if (typeStr == HttpContentType.Json.ToString())
            {
                return new JsonGenerator();
            }
            else
            {
                return new FormGenerator();
            }
        }
    }
}
