using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.Device
{
    internal class Car : Device
    {
        public override void Desc()
        {
            Console.WriteLine("для перемещение из точки А в точку Б");
        }

        public override void Show()
        {
            Console.WriteLine("Car");
        }

        public override void Sound()
        {
            Console.WriteLine("Ды дын");
        }
    }
}
