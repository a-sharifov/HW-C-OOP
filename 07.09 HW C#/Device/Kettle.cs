using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.Device
{
    internal class Kettle : Device
    {
        public override void Desc()
        {
            Console.WriteLine("чтоб разогревать воду");
        }

        public override void Show()
        {
            Console.WriteLine("чайник");
        }

        public override void Sound()
        {
            Console.WriteLine("вжжжжж......");
        }
    }
}
