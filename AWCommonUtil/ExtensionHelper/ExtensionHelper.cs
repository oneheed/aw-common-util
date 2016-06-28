using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil
{
    /// <summary>
    /// Some extension methods for object
    /// </summary>
    public static class ExtensionHelper
    {
        /// <summary>
        /// 如果為null則回傳empty，反之為一般的ToString()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SafeToString(this object obj)
        {
            return (obj ?? string.Empty).ToString();
        }

        /// <summary>
        /// 將物件轉成T型別
        /// 若無法轉型，則回傳default(T)
        /// For example, return default(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToGetValue<T>(this object obj)
        {
            return ToGetValue<T>(obj, default(T));
        }

        /// <summary>
        /// 將物件轉成T型別
        /// 若無法轉型，則回傳輸入的defaultValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToGetValue<T>(this object obj, T defaultValue)
        {
            //if the T is string and it's null, then return defaultValue
            if (typeof(T) == typeof(string))
            {
                var cObj = obj.ToConvert(defaultValue);
                if (cObj == null)
                {
                    return defaultValue;
                }
                return cObj;
            }

            return obj.ToConvert(defaultValue);
        }

        //public static T DeepClone<T>(this T srcObj)
        //{
        //    T dstObj;
        //    var dcs = new DataContractSerializer(typeof(T));
        //    using (var ms = new MemoryStream())
        //    {
        //        dcs.WriteObject(ms, srcObj);
        //        ms.Position = 0;
        //        dstObj = (T)dcs.ReadObject(ms);
        //    }
        //    return dstObj;
        //}

        //public static TEnum ToEnumOrDefault<TEnum>(this Object item)
        //{
        //    try
        //    {
        //        var enumerate = Enum.Parse(typeof(TEnum), item.ToString());
        //        return (TEnum)enumerate;
        //    }
        //    catch
        //    {
        //        return Activator.CreateInstance<TEnum>();
        //    }
        //}

        #region 轉換器
        private static T ToConvert<T>(this object obj, T defaultValue)
        {
            try
            {
                var type = typeof(T);

                //ex. int?、double? 
                if (type.IsValueType && !type.IsPrimitive && type.IsGenericType)
                {
                    type = type.GetGenericArguments()[0];
                }

                return (T)Convert.ChangeType(obj, type);
            }
            catch
            {
                return defaultValue;
            }
        }
        #endregion
    }
}

