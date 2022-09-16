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
    [Serializable]
    internal class MoneyConverterHistory
    {
        public LinkedList<MoneyConverter> History { get; set; }
        public int Count
        {
            get
            {
                if(History == null) return 0;
                return History.Count;
            }
        }
        public MoneyConverterHistory(params MoneyConverter[]? moneyConverters)
        {
            History = new LinkedList<MoneyConverter>();
            if(moneyConverters!= null)
            foreach (var item in moneyConverters)
            {
                this.AddToHistory(item);
            }
        }
        public void AddToHistory(MoneyConverter money)
        {
            this.History?.AddLast(money);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (this.History != null)
            {
                foreach (var item in this.History)
                {
                    builder.Append($"{item.ToString()}\n");
                }
            }
            return builder.ToString();
        }
    }
}
