using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil
{
    /// <summary>
    /// Some extension methods for Dictionary
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        /// Convert dictionary to ExpandoObject
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static ExpandoObject ToExpando(this IDictionary<string, object> dict)
        {
            var obj = new ExpandoObject();
            var tmpDict = (ICollection<KeyValuePair<string, object>>)obj;

            foreach (var kvp in dict)
            {
                tmpDict.Add(kvp);
            }
            dynamic eoDynamic = obj;
            return eoDynamic;
        }

        /// <summary>
        /// Try to get value from the dictionary, and return a tuple
        /// The item[0] is get value succeed or not, item[1] is default(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Tuple<bool, T2> TryGetValue<T, T2>(this IDictionary<T, T2> dict, T key)
        {
            try
            {
                T2 v;
                var result = dict.TryGetValue(key, out v);
                return new Tuple<bool, T2>(result, v);
            }
            catch { }
            return new Tuple<bool, T2>(false, default(T2));
        }

        /// <summary>
        /// Try to add/update the key/value into the dictionary.
        /// if the dictionary contains the key already, then update the old value by input value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void TryAddOrUpdate<T, T2>(this IDictionary<T, T2> dict, T key, T2 value)
        {
            if (dict == null || key == null)
                return;

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            else
            {
                dict[key] = value;
            }
        }

        /// <summary>
        /// Try add the key/value into the dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void TryAdd<T, T2>(this IDictionary<T, T2> dict, T key, T2 value)
        {
            if (dict == null || key == null)
                return;

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
        }

        /// <summary>
        /// Try get value from the dictionary by the key in case insensitive.
        /// The performance is bad.
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object TryGetValueIgnoreCase(this IDictionary<string, object> dict, string key)
        {
            try
            {
                foreach (var k in dict.Keys)
                {
                    if (k.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                        return dict[k];
                }
            }
            catch { }
            return null;
        }
    }
}
