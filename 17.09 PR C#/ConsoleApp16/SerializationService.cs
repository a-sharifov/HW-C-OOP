using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeserializeTest
{
    public class SerializationService
    {
        public static void Serialize<T>(T data)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var res = JsonConvert.SerializeObject(data, settings);

            using var fs = new FileStream("data.txt", FileMode.Create);
            using var sw = new StreamWriter(fs);
            sw.Write(res);
        }
        public static List<Iserializable> Deserialize(string data)
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.All
            };

         return JsonConvert.DeserializeObject<List<Iserializable>>(data, settings) ?? throw new NullReferenceException();
        }
    }
}
