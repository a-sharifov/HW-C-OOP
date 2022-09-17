using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class MoneyConverter
    {
        public string? date { get; set; }
        public Info info { get; set; }
        public Query query { get; set; }
        public float result { get; set; }
        public bool success { get; set; }

        public class Info
        {
            public float rate { get; set; }
            public int timestamp { get; set; }
        }

        public class Query
        {
            public float amount { get; set; }
            public string from { get; set; }
            public string to { get; set; }
        }
        public override string ToString() => $"{query.from}: {query.amount} == {query.to}: {result}";
    }
}


