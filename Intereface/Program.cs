

namespace ConsoleApp10
{
    class Program
    {
        public static void Main()
        {
            MyArray avc = new MyArray(100,7,4,3,2,54,6,4,32,4,4);
            avc.Add(1, new Int32[] {1,2,3,4,5} );
            avc.SortShell();
            for (int i = 0; i < avc.Length; i++)
            {
                Console.Write($"{avc[i]} ");
            }
            Console.WriteLine($"\n{avc.CountDistinct()}");
        }
    }
}