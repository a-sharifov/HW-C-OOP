// Exception - исключения 
// Правило №1: Нужно писать свои исключения 
// Правило №2: Не надо использовать их где попало
// Правило №3: Если исключение можно заменить условием и это решает проблему, сделай это.
// Но подумай еще раз перед этим )) 

using ExceptionLesson;
using MyException;
using System.IO;

#region Bred1

// int a = 2;
// int b = 0;


// try
// {
// Console.WriteLine(a / b);
// }
// catch (System.Exception ex)
// {
// Console.WriteLine(ex.Message);
// }

#endregion


#region NeBred1

var group = new Group()
{
    Capacity = 5,
    Teacher = new() { Age = 20, Name = "Elvin", Surname = "Azimov", Salary = Int32.MaxValue },
    Students = new()
    {
        new("Omar", "Xayyam", 20),
        new("Medina", "Abbasova", 19),
        new("Shems", "Ismayilova", 18),
        new("Fidan", "Axundbeyli", 19),
        new("Akber", "Sharifov", 18)
    }
};


try
{
    group.AddStudent(new("Maksimus", "Prime", 15));
}
catch (StudentException ex)
{
    Console.WriteLine(ex.Source);
    using(FileStream fs = new FileStream("error.log" , FileMode.Create))
    {
        using(StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine($"{DateTime.Now.ToString("yyyy:MM:dd")} - {ex.Source}, {ex.HResult}");
        }
    }
}



#endregion