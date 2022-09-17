using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class MoneyClient
    {
        public const string _key = "P4UwunHfmFXlLEpF2rSiQ1vtp1WeobCi";
        public const string _url = @"https://api.apilayer.com/exchangerates_data/convert?";
        public static MoneyConverter MoneyConverter(string tokenA ,string tokenB , float count)
        {
            var client = new WebClient();
            var Downoload = client.DownloadString($"{_url}apikey={_key}&to={tokenA}&from={tokenB}&amount={count}");
            if (Downoload != null)
            {
                var File = JsonSerializer.Deserialize<MoneyConverter>(Downoload); //так как не прошли exception сделал так
                if (File != null) return File;
                throw new NullReferenceException();
            }
            else throw new NullReferenceException();
        }
    }
}
