
namespace ConsoleApp4
{
    class Program
    {
        public static fraction solution_fraction(char solution, ref fraction A, fraction B) => solution switch
        {
            '*' => A *= B,
            '/' => A /= B,
            '+' => A += B,
             _ => A -= B
        };

        public static void Main()
        {
            Console.Write("enter dividend 1 : ");
            Int32 dividend1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter divider 1 : ");
            Int32 divider1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter dividend 2 : ");
            Int32 dividend2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter divider 2 : ");
            Int32 divider2 = Convert.ToInt32(Console.ReadLine());

            fraction A = new fraction(dividend: dividend1,divider: divider1), B = new fraction(dividend: dividend2, divider: divider2);

            Console.Write("enter ( * / + - ) : ");
            Char select = Convert.ToChar(Console.Read());

            solution_fraction(solution: select, A: ref A, B: B);

            Console.WriteLine(A);

        }
    }
}