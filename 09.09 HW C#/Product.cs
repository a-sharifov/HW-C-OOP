using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    [Serializable]
    public class Product
    {
        public uint Count { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public Product(uint Count, uint Price, string Name)
        {
            this.Count = Count;
            this.Price = Price;
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"Name - {this.Name}\n" +
                   $"Price - {this.Price}\n" +
                   $"Count - {this.Count}\n";
        }
    }
}
