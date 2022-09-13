using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.MusicInstrument
{
    public class Violin : MusicInstrument
    {
        public override void Desc()
        {
            Console.WriteLine("три струны");
        }

        public override void History()
        {
            Console.WriteLine("создали 1704г");
        }

        public override void Show()
        {
            Console.WriteLine("Violin");
        }

        public override void Sound()
        {
            Console.WriteLine("дзыыын дзыын 🤨");
        }
    }
}
