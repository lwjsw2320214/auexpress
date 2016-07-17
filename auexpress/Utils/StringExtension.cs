using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace auexpress.Utils
{
    public static class StringExtension
    {

        public static string ToJson(this object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());

            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, obj);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T JsonToObject<T>(this string jsonStr)
        {
            Type type = typeof(T);

            return (T)type.JsonToObject(jsonStr);
        }

        public static object JsonToObject(this Type type, string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr)) throw new ArgumentNullException("jsonStr");

            DataContractJsonSerializer json = new DataContractJsonSerializer(type);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
            {
                try
                {
                    return json.ReadObject(stream);
                }
                catch (Exception e)
                {
                    throw new ArgumentOutOfRangeException("将对象反序列化失败。\r\n" + jsonStr, e);
                }
            }
        }

    }
}
