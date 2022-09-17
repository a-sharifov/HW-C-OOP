namespace DeserializeTest;

public class Person : Iserializable
{
    public string ?name { get; set; }
    public string ?surname { get; set; }
    public int age { get; set; }

    public override string ToString()
    {
        return $"Name - {name}\n" +
            $"Surname - {surname}\n" +
            $"Age - {age}\n\n";
    }
}
