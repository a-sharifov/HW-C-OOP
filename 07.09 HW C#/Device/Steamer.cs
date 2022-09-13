using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.Device
{
    internal class Steamer : Device
    {
        public override void Desc()
        {
            Console.WriteLine("для пермещение предметов на далекие расстояние");
        }

        public override void Show()
        {
            Console.WriteLine("Steamer");
        }

        public override void Sound()
        {
            Console.WriteLine("вжж вжжжун....");
        }
    }
}
