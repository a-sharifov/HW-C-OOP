using ConsoleApp17;
using System.IO;
using System.Xml.Serialization;



Book Books = new Book()
{
    NameBook = "Fairy Tale",
    AuthorsName = "Stephen",
    AuthorsSurname = "King",
    Description = "blblblbllblb"
};

Book Books1 = new Book()
{
    NameBook = "GreenLights",
    AuthorsName = "Mathew",
    AuthorsSurname = "McConauqhey",
    Description = "blblblbllblb"
};

Book Books2 = new Book()
{
    NameBook = "Attack on Titan",
    AuthorsName = "Isayama",
    AuthorsSurname = "Hajime",
    Description = "lslslslslsz",
};

Library library = new Library();
library.AddBook(Books);
library.AddBook(Books1);
library.AddBook(Books2);

XmlSerializer xmlSerializer = new XmlSerializer(typeof(Library));
using(FileStream fs = new FileStream("Library.txt"  , FileMode.Create))
{
    xmlSerializer.Serialize(fs , library);
}

Library? library1;
using (FileStream fs = new FileStream("Library.txt", FileMode.Open))
{
    library1 = xmlSerializer.Deserialize(fs) as Library;
}

Console.WriteLine(library1?[0].ToString());


