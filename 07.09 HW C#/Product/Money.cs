using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    public class Money
    {
        public Int32 WholePart { get; protected set; }
        public Int32 fractionalPart { get; protected set; }
        public String currency { get; }
        public Money(String currency, Int32 WholePart, Int32 fractionalPart)
        {
            this.currency = currency;
            this.WholePart = WholePart;
            this.fractionalPart = fractionalPart;
        }
    }
}
