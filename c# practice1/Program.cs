
namespace homework
{
    class program
    {
        public static void sort_massive(int[] massive_user) {
            for (int i = 0; i < massive_user.Length; i++)
            {
                for (int j = 0; j < massive_user.Length-1; j++)
                {
                    if(massive_user[i] > massive_user[j])
                    {
                        int tmp = massive_user[i];
                        massive_user[i] = massive_user[j];
                        massive_user[j] = tmp;
                    }
                }
            }
        }

        public static void print_massive_odd_even(int[] massive_user)
        {
            var massive_copy = new int[massive_user.Length];
            massive_user.CopyTo(massive_copy, 0);
            sort_massive(massive_copy);
            Console.Write("even : ");
            if (massive_copy[0] % 2 == 0) { Console.Write($"{massive_copy[0]} "); }
            for (int i = 1; i < massive_copy.Length; i++)
            {
                if((massive_copy[i]%2 == 0 && massive_copy[i-1] != massive_copy[i]))
                {
                    Console.Write($"{massive_copy[i]} ");
                }
            }
            Console.WriteLine();
            Console.Write("odd : ");
            if (massive_copy[0] % 2 == 1) { Console.Write($"{massive_copy[0]} "); }
            for (int i = 1; i < massive_copy.Length; i++)
            {
                if ((massive_copy[i] % 2 == 1 && massive_copy[i - 1] != massive_copy[i]))
                {
                    Console.Write($"{massive_copy[i]} ");
                }
            }
            Console.WriteLine();
        }

        public static void number_less(int number , int[] massive_user){
            for (int i = 0; i < massive_user.Length; i++)
            {
                if (number > massive_user[i])
                {
                    Console.Write($"{massive_user[i]} ");
                }
            }
            Console.WriteLine(" - less than");
        }
        
        public static int is_3numbers(int[] massive1 ,int[] massive2)
        {
            if(massive1.Length == 3 && massive2.Length >= 3)
            {
                int is_number = new();
                for (int i = 0; i < massive2.Length-2; i++)
                {
                    for (int j = 0; j < massive1.Length; j++ , i++)
                    {
                        if(massive1[j] != massive2[i])
                        {
                            i -= j;
                            break;
                        }
                        if(j == massive1.Length - 1)
                        {
                            is_number++;
                            i -= j;
                        }
                    }
                }
                return is_number;
            }
            return 0;
        }

        public static void Main()
        {
            Int32[] mass = new int[] { 1, 2, 3, 10, 11, 12, 4, 5, 2, 556 };
            Int32[] mass_search = new int[] { 1, 2, 3 };
            Int32 number = new();
            print_massive_odd_even(mass);

            Console.Write("enter number : ");
            Boolean number_bool = Int32.TryParse(Console.ReadLine(), out number);
            if (number_bool)
            {
                number_less(number, mass);
            }
            Int32 search_count  = is_3numbers(mass_search, mass);
            Console.Write($"{search_count} - count is - ");
            for (int i = 0; i < mass_search.Length; i++)
            {
                Console.Write($"{mass_search[i]} ");
            }
        }

    }
}