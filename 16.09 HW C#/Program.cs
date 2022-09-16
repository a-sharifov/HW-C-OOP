using ConsoleApp14;
using System.Net;
using System.Text.Json;
using System.Xml.Serialization;

var money = MoneyClient.MoneyConverter("USD", "RUB", 11);
var money1 = MoneyClient.MoneyConverter("EUR", "USD", 150);
var money2 = MoneyClient.MoneyConverter("USD", "RUB", 12);
//Console.WriteLine(money?.ToString());
if(money != null) SeriliazibleFile<MoneyConverter>.SeriliazibleAs(money, "aaa1.txt");
var a = SeriliazibleFile<MoneyConverter>.DesriliazibleAs("aaa1.txt");
//Console.WriteLine(a?.ToString());



var history = new MoneyConverterHistory(money, money1, money2);

SeriliazibleFile<MoneyConverterHistory>.SeriliazibleAs(history, "111.txt"); 
//Console.WriteLine(s);
var history1 = SeriliazibleFile<MoneyConverterHistory>.DesriliazibleAs("111.txt");
Console.WriteLine(history1.ToString());
