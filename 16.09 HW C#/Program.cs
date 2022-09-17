using ConsoleApp14;
using System.Net;
using System.Text.Json;
using System.Xml.Serialization;


var money = MoneyClient.MoneyConverter("USD", "RUB", 11);
var money1 = MoneyClient.MoneyConverter("EUR", "USD", 150);
var money2 = MoneyClient.MoneyConverter("TRY", "EUR", 12);
////Console.WriteLine(money?.ToString());
//SeriliazibleFile<MoneyConverter>.SeriliazibleAs(money, "aaa1.txt");
var a = SeriliazibleFile<MoneyConverter>.DesriliazibleAs("aaa1.txt");
////Console.WriteLine(a?.ToString());



var history = new MoneyConverterHistory();
history.AddToHistory(a);
history.AddToHistory(money1);
history.AddToHistory(money2);

SeriliazibleFile<MoneyConverterHistory>.SeriliazibleAs(history, "121.json");
Console.WriteLine(history);
var history1 = SeriliazibleFile<MoneyConverterHistory>.DesriliazibleAs("121.json");
Console.WriteLine(history1.ToString());


//var A = new List<MoneyConverter>();
//A.Add(money);
//A.Add(money1);
//A.Add(money2);
//SeriliazibleFile<List<MoneyConverter>>.SeriliazibleAs(A, "121.json");
//var history1 = SeriliazibleFile<List<MoneyConverter>>.DesriliazibleAs("121.json");
//foreach (var item in history1)
//{
//    Console.WriteLine(item.ToString());
//}