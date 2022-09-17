using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class MoneyConverterHistory
    {
        public LinkedList<MoneyConverter> History { get; set; } = new LinkedList<MoneyConverter>();

        public void AddToHistory(MoneyConverter money)
        {
            history.AddLast(money);
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
                foreach (var item in history)
                {
                    builder.Append($"{item.ToString()}\n");
                }
            return builder.ToString();
        }
    }
}
