using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    public class Product : Money
    {
       public string NameProduct { get; }
        public Product(string NameProduct ,String currency, Int32 WholePart, Int32 fractionalPart):base(currency , WholePart, fractionalPart)
        {
            this.NameProduct = NameProduct;
        }

        public void RedactSum(Int32 WholePart, Int32 fractionalPart)
        {
            this.WholePart = WholePart;
            this.fractionalPart = fractionalPart;
        }

    }
}
