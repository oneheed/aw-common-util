using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AWCommonUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            TestHttp();
            //TestDict();
            //TestDataSet();
        }

        private static void TestDataSet()
        {
            var ds = new DataSet();
            var r = ds.Tables.TryGetTable(0).TryGetRow(0);
            var c = r.TryGetValue("xxx");
        }

        private static void TestDict()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("a", "aa");
            dic.Add("b", "bb");
            Console.WriteLine(dic.TryGetValueIgnoreCase("a"));
            Console.WriteLine(dic.TryGetValueIgnoreCase("B"));
            var dic3 = new Dictionary<int, int>();
            var aaa = dic3.TryGetValue(1);
            dic3.TryAddOrUpdate(3, 33333);
            dic3.TryAddOrUpdate(3, 3);
            dic3.TryAdd(3, 5);
            dic3.TryAdd(4, 4);
            Console.WriteLine(aaa);
        }

        private static void TestHttp()
        {
            var str = HttpUtil.Execute("http://linkapi.bcbc16.com/app/WebService/JSON/display.php/CheckUsrBalance",
            new { website = "bet16", username = "b16wbet16rmb001", uppername = "dbet16", key = "123456783530d74426df07588a75c66a4511ff4012" },
            HttpMethod.GET,
            HttpContentType.FormUrlEncode);
            Console.WriteLine(str);


            var str5 = HttpUtil.GetRespByExecute("http://zeus.vw.local/Mercury/TP/vwin/GamesOS/validate_ticket",

                      new
                      {
                          ticket = "xvwinliorwenrox1$nINiiQGMueSED9Z4yaq1",
                          merch_id = "VWIN",
                          merch_pwd = "aie1bPRYc1wu",
                          IP = "10.10.10.10"
                      },
                         HttpMethod.POST,
                         HttpContentType.Json);
            Console.WriteLine(str5);
            var str2 = HttpUtil.Execute("http://10.10.102.112/Mercury/Game/GetBalance",
                        new
                        {
                            token = "6fc448bc-02ba-41dc-911d-38c37557f194",
                            inputdata = new { PlatformCode = "60001" }
                        },
               HttpMethod.POST,
               HttpContentType.Json);
            Console.WriteLine(str2);

            var str3 = HttpUtil.Execute(string.Format("http://wsgd.gdsecure88.com/MerchantAPI/ewallet.php"),
                 XDocument.Parse("<Request>  <Header>    <Method>cGetTotalMemberBalance</Method>    <MerchantID>VWINtest</MerchantID>    <MessageID>T160204103838cda19</MessageID>  </Header>  <Param>    <CurrencyCode>CNY</CurrencyCode>  </Param></Request>"),
                 HttpMethod.POST, HttpContentType.TextXml);
            Console.WriteLine(str3);

            var strGet = HttpUtil.Execute("http://10.10.102.112/apis/values/Encrypt",
                 new { str = "ssss" },
                 HttpMethod.GET,
                 HttpContentType.FormUrlEncode);
            Console.WriteLine(strGet);
        }
    }
}
