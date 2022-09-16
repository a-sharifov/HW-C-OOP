using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal static class SeriliazibleFile<T>
    {
        public static string Seriliazible(T file)
        {
            return JsonSerializer.Serialize(file);
        }

        public static void SeriliazibleAs(T file, string Where)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            FileManager.SaveAs(JsonSerializer.Serialize(file , options), Where);
        }

        public static T DesriliazibleAs(string Where)
        {
            var File = JsonSerializer.Deserialize<T>(FileManager.DownoloadAs(Where));
            if (File == null) throw new NullReferenceException();
            return File;
        }
    }
}
