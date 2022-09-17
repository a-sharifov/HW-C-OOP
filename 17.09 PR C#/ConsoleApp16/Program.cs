using System.Net;
using ConsoleApp16;
using DeserializeTest;
using Newtonsoft.Json;

List<Iserializable> people = new()
{
    new Person()
    {
        name = "Elvin",
        surname = "Azimov",
        age = 20
    },
    new Student()
    {
        name = "Omar",
        surname = "Haciyev",
        age = 20,
        semester = 2,
        gpa = 12
    }
};

SerializationService.Serialize(people);




using var fs = new FileStream("data.txt", FileMode.Open);
using var sr = new StreamReader(fs);

var a = SerializationService.Deserialize(sr.ReadToEnd()) ;
foreach (var item in a)
{
    Console.WriteLine(item.ToString());
}
