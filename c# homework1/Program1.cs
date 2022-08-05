namespace HomeWork
{
    class Program
    {
        public static void Fizz_Buzz(Int32 number)
        {
            if (number > 0 && number < 101)
            {
                if (number % 3 == 0 && number % 5 == 0) System.Console.WriteLine("Fizz Buzz");
                if (number % 3 == 0) System.Console.WriteLine("Fizz");
                if (number % 5 == 0) System.Console.WriteLine("Buzz");
                else System.Console.WriteLine(number);
            }
        }
        public static int merge_Numbers(int number1, int number2, int number3, int number4) { return (number1 * 1000) + (number2 * 100) + (number3 * 10) + number4; }
        public static double percent(Double number , Double divider) { return number / divider; }
        public static void my_Swap(int number_swap)
        {
            if (number_swap <= 999_999 && number_swap >= 100_000)
            {
                System.Console.WriteLine($"your number {number_swap}");
                System.Console.Write("enter index 1 :");
                Int32 index1 = new();
                var index1_bool = Int32.TryParse(System.Console.ReadLine() , out index1);
                if(index1_bool)
                {
                    Int32 a = (int)(Math.Pow(10, index1 + 1)) / 10;//возвращает число в степени
                    int a_number = (number_swap / (int)a) % 10;
                    System.Console.Write("enter index 2 :");
                    Int32 index2 = new();
                    var index2_bool = Int32.TryParse(System.Console.ReadLine(), out index2);
                    if (index2_bool)
                    {
                        Int32 b = (int)(Math.Pow(10, index2 + 1)) / 10;
                        Int32 b_number = (number_swap / (int)b) % 10;
                        number_swap -= ((a * a_number) + (b * b_number)) - ((a * b_number) + (b * a_number));
                        System.Console.WriteLine($"swap number - {number_swap}"); //желательнее сделать ворвзвращаемый тип
                    }
                }
            }
            else Console.WriteLine("is not six digit number");
        }

        public static void date_Print(int year, int month, int day)
        {
            System.DateTime user_date = new(year, month, day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);
            System.Console.WriteLine(user_date.ToString("\nHH:mm:ss \ndddd d MMMM")); //выставил некторые параметры по текущему времени компьютера 
        }

        public static void Main()
        {
            //1
            Fizz_Buzz(10);
            //2
            System.Console.WriteLine($"{percent(90, 10)} - percent 90/10");
            //3
            System.Console.WriteLine($"{merge_Numbers(1, 2, 3, 4)}  - merge 1 2 3 4");
            //4
            Int32 number_swap;
            System.Console.Write("enter your number : ");
            Boolean true_number_swap = Int32.TryParse(System.Console.ReadLine() , out number_swap);
            if (true_number_swap) my_Swap(number_swap);

            //5
            Byte day = new(), month = new();
            UInt16 year = new();
            System.Console.Write("enter day : ");
            Boolean true_day = Byte.TryParse(System.Console.ReadLine(), out day);
            if (true_day)
            {
                System.Console.Write("enter month : ");
                Boolean true_month = Byte.TryParse(System.Console.ReadLine(), out month);
                if (true_month)
                {
                    System.Console.Write("enter year : ");
                    Boolean true_year = UInt16.TryParse(System.Console.ReadLine(), out year);
                    if (true_year) date_Print(year, month, day);
                }
            }

            //6 
            Single temperature = new();
            Byte select = new();
            Console.Write("enter temperature : ");
            var bool_degree = Single.TryParse(Console.ReadLine(), out temperature);
            if (bool_degree)
            {
                Console.Write("\ntranslate select 1 - farenheit 2 - celcius : ");
                var bool_select = Byte.TryParse(Console.ReadLine(), out select);
                if (bool_select)
                {
                    if (select == 1) temperature = (temperature * 1.8f) + 32;
                    else temperature = (temperature - 32) / 1.8f;
                    System.Console.WriteLine($"temperature - {temperature}");
                }
            }

            //7
            Int32 a = new() , b = new();
            Console.Write("enter start : ");
            var bool_a = Int32.TryParse(Console.ReadLine(), out a);
            Console.Write("enter end : ");
            var bool_b = Int32.TryParse(Console.ReadLine(), out b);
            if(a > b)
            {
                var c = a;
                a = b;
                b = c;
            }
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0) Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}    