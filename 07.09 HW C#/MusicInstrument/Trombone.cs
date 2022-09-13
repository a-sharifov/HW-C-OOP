using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.MusicInstrument
{
    public class Trombone : MusicInstrument
    {
        public override void Desc()
        {
            Console.WriteLine("большой инструмент");
        }

        public override void History()
        {
            Console.WriteLine("появился в XV ыеку");
        }

        public override void Show()
        {
            Console.WriteLine("Trombone");
        }

        public override void Sound()
        {
            Console.WriteLine("вжууун вжууунн.....");
        }
    }
}
