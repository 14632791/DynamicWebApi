using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Southernfund.UpdateSystem.Model.Util
{
    public static class JsonHelper
    {
        /// <summary>
        ///json解析对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>对象实体</returns>
        public static T JsonDe<T>(this string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                    return default(T);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("JsonHelper-JsonDe", e);
                return default(T);
            }
        }

        /// <summary>
        /// 对象转换为json
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>json字符串</returns>
        public static string JsonSe(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
                //return JsonConvert.SerializeObject(obj, null, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("JsonHelper-JsonDe", e);
                return string.Empty;
            }
        }

        /// <summary>
        /// 对象转换为json，排除死循环
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>json字符串</returns>
        public static string JonsSeWithoutSelfLoop(this object obj)
        {
            try
            {
                //return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.All });
                return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("JsonHelper-JonsSeWithoutSelfLoop", ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// 对象转化为linqobject
        /// </summary>
        /// <param name="json">jsos字符串</param>
        /// <returns></returns>
        public static JObject JsonLinq(this string json)
        {
            return JObject.Parse(json);
        }

      
        /// <summary>
        /// 解析json为TYResultModel返回对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonDe(this string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }

     
    }
}
