using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    [Serializable]
    public class Book
    {
        public string NameBook { get; set; } = "default";
        public string ?AuthorsName { get; set; }
        public string ?AuthorsSurname { get; set; }
        public string ?Description { get; set; }


        public override string ToString()
        {
            return $"Name : {NameBook}\n" +
                   $"Authors name : {AuthorsName}\n" +
                   $"Authors surname : {AuthorsSurname}\n" +
                   $"Description - {Description}\n\n";
        }
    }
}
