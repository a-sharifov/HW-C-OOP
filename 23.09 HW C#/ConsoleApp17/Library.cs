using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    [Serializable]
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>(); 
        public void AddBook(Book book)
        {
                Books.Add(book);
        }

        public void DeleteBook(int i)
        { 
                Books.RemoveAt(i);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in Books)
            {
                builder.Append(item.ToString());
            }
            return builder.ToString();
        }

        public Book this[int i]
        {
            get { return Books[i]; }
        }

    }
}
