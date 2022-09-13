using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.Worker
{
    public class Engineer : Worker
    {
        public override void Print()
        {
            Console.WriteLine("я энжинер");
        }
    }
}
