using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Ame.Twitter.Ultility
{
    public class JsonSerializer<T>
    {
        public static T ToObject(string json)
        {
            var ser = new DataContractJsonSerializer(typeof(T));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var result = (T)ser.ReadObject(stream);
                return result;
            }
        }

        public static string ToJsonString(T obj)
        {
            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms,obj);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json,0,json.Length);
        }
    }
}
