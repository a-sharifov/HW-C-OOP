
namespace homework
{
    class program
    {
        public static void print_2massive(Int32[,] A , Int32 length , Int32 width)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                    Console.Write($"{A[i,j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void task1()
        {
            Random rand = new();
            Int32[] A = new Int32[5];
            Int32[,] B = new Int32[3, 4];

            for (Int32 i = 0; i < A.Length; i++)
            {
                Console.Write("enter number : ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nyour massive A ");
            for (Int32 i = 0; i < A.Length; i++)
                Console.Write($"{A[i]} ");

            for (Int32 i = 0; i < 3; i++)
            {
                for (Int32 j = 0; j < 4; j++)
                    B[i, j] = rand.Next() % 10;
            }

            Console.WriteLine("\n\nrand massive B ");
            for (Int32 i = 0; i < 3; i++)
            {
                for (Int32 j = 0; j < 4; j++)
                    Console.Write($"{B[i, j]} ");
                Console.WriteLine();
            }

            Int32 maxElement = Int32.MinValue;
            Int32 minElement = Int32.MaxValue;

            for (Int32 i = 0; i < A.Length; i++)
            {
                for (Int32 j = 0; j < 3; j++)
                {
                    for (Int32 c = 0; c < 4; c++)
                    {
                        if (A[i] == B[j, c] && maxElement < B[j, c]) maxElement = A[i];
                        else if (A[i] == B[j, c] && minElement > B[j, c]) minElement = A[i];
                    }
                }
            }

            Console.WriteLine($"\nMax common element : {(maxElement == Int32.MinValue ? "none" : maxElement)}");
            Console.WriteLine($"Min common element : {(minElement == Int32.MaxValue ? "none" : minElement )}");
            Int32 sum = new();
            Int32 even_A = new(), odd_B = new();

            for (Int32 i = 0; i < A.Length; i++)
            {
                sum += A[i];
                if (i % 2 == 1) even_A += A[i];
            }

            for (Int32 i = 0; i < 3; i++)
            {
                for (Int32 j = 0; j < 4; j++)
                {
                    sum += B[i, j];
                    if (j % 2 == 0) odd_B += B[i, j];
                }
            }
            Console.WriteLine($"\nsum element : {sum}");
            Console.WriteLine($"even sum A element : {even_A}");
            Console.WriteLine($"odd sum B element : {odd_B}\n");
        }
        public static void task2()
        {
            Random rand = new(); // желательно использовать один Random
            Int32[,] A = new Int32[5, 5];
            Int16 start_pillar = new() , end_pillar = new() ,start_line = new(), end_line = new();

            for (Int32 i = 0; i < 5; i++)
            {
                for (Int32 j = 0; j < 5; j++)
                {
                    A[i, j] = rand.Next() % 201 - 100;
                    Console.Write($"{A[i,j]} ");
                }
                Console.WriteLine();
            }

            for (Int16 i = 0; i < 5; i++)
            {
                for (Int16 j = 0; j < 5; j++)
                {
                    if (A[start_pillar, start_line] > A[i, j])
                    {
                        start_pillar = i;
                        start_line = j;
                    }
                    else if (A[end_pillar, end_line] < A[i, j])
                    {
                        end_pillar = i;
                        end_line = j;
                    }
                }
            }

            if((start_pillar > end_pillar) || (start_pillar == end_pillar && start_line > end_line))
            {
                Int16 tmp = start_pillar;
                start_pillar = end_pillar;
                end_pillar = tmp;

                tmp = start_line;
                start_line = end_line;
                end_line = tmp;
            }

            Int32 sum = new();
            for (Int32 i = start_line; i < 5; i++)
                sum += A[start_pillar, i];
            for (Int32 i = start_pillar+1; i < end_pillar; i++)
            {
                for (Int32 j = 0; j < 5; j++)
                    sum += A[i, j];
            }
            for (Int32 i = 0; i <= end_line; i++)
                sum += A[end_pillar, i];
            Console.WriteLine($"\nsum max-min : {sum}");
        }
        public static void task3()
        {
            Console.Write("enter text : ");
            String? text = Console.ReadLine();
            Console.Write("enter key number : ");
            UInt16 key = Convert.ToUInt16(Console.ReadLine());
            Char[] text1 = text.ToCharArray();
            String alphabet = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";

            for (int i = 0; i < text1.Length; i++)
            {
                if(Char.IsLetter(text1[i]))
                    text1[i] = alphabet[((alphabet.IndexOf(text1[i])+key)%alphabet.Length)] ; //IndexoF - первое вхождение ищем где находиться эта число и ставим рамки в виде %
            }
            Console.Write(text1);
            Console.WriteLine(" - encryption");
            Int32 tmp = new();
            for (int i = 0; i < text1.Length; i++)
            {
                if (Char.IsLetter(text1[i]))
                {
                    tmp = alphabet.IndexOf(text1[i]) - key%alphabet.Length; //%length  нужен для того чтоб сделал как будто повторный круг
                    if (tmp < 0)
                        tmp += alphabet.Length;
                    text1[i] = alphabet[tmp];
                }
            }
            Console.Write(text1);
            Console.WriteLine(" - decoding\n");
        }
        public static void task4()
        {
            Random rand = new(); // желательно использовать один Random
            Int16 length = new(), width = new();
            Console.Write("enter length : ");
            length = Convert.ToInt16(Console.ReadLine());
            Console.Write("enter width : ");
            width = Convert.ToInt16(Console.ReadLine());

            Int32[,] A = new Int32[width, length];
            Int32[,] B = new Int32[width, length];

            for (Int32 i = 0; i < width; i++)
            {
                for (Int32 j = 0; j < length; j++)
                {
                    A[i, j] = rand.Next() % 10;
                    B[i, j] = rand.Next() % 10;
                }
            }
            print_2massive(A, width, length);
            print_2massive(B, width, length);

            Console.Write("enter number : ");
            var number = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("\nmultipl number");
            for (Int32 i = 0; i < width; i++)
            {
                for (Int32 j = 0; j < length; j++)
                    Console.Write($"{A[i, j]*number} ");
                Console.WriteLine();
            }
            Console.WriteLine();

            for (Int32 i = 0; i < width; i++)
            {
                for (Int32 j = 0; j < length; j++)
                    Console.Write($"{B[i, j] * number} ");
                Console.WriteLine();
            }
            Console.WriteLine("\nmatrix addition");
            for (Int32 i = 0; i < width; i++)
            {
                for (Int32 j = 0; j < length; j++)
                    Console.Write($"{B[i, j] + A[i,j]} ");
                Console.WriteLine();
            }
            Console.WriteLine("\nmatrix product");
            for (Int32 i = 0; i < width; i++)
            {
                for (Int32 j = 0; j < length; j++)
                    Console.Write($"{B[i, j] * A[i, j]} ");
                Console.WriteLine();
            }
        }
        public static void task5()
        {
            Int32 A  = new(), B = new();
            Int32 multi = 1;
            Char sign = new();
            Console.Write("enter an expression : ");
            String ?expression = Console.ReadLine();
            Int32 i = expression.Length - 1;
            for (; i >= 0; i--)
            {
                if (Char.IsNumber(expression[i]))
                {
                    A +=  (multi * (expression[i]-48));
                    multi *= 10;
                }
                else
                {
                    sign = expression[i--];
                    break;
                }
            }
            multi = 1;
            for ( ; i >= 0;i--)
            {
                if (Char.IsNumber(expression[i]))
                {
                    B += (multi * (expression[i] - 48));
                    multi *= 10;
                }
            }
            switch (sign)
            {
                case '+':
                    Console.WriteLine(A + B);
                    break;
                case '*':
                    Console.WriteLine(A * B);
                    break;
                case '-':
                    Console.WriteLine(A - B);
                    break;
                default:
                    Console.WriteLine(A / B);
                    break; //без него выдовало ошибку 
            }
        }

        public static void task6()
        {
            Console.Write("enter text : ");
            String? text = Console.ReadLine();
            Char[] text1 = text.ToCharArray();

            for (Int32 i = 0; i < text1.Length; i++)
            {
               if(i == 0 || Char.IsPunctuation(text1[i - 1]))
                    text1[i] = Char.ToUpper(text1[i]);
            }
            Console.WriteLine(text1);
        }
        public static void task7()
        {
            Console.Write("enter text : ");
            String? text = Console.ReadLine();
            Char[] text1 = text.ToCharArray();
            Console.Write("enter word : ");
            String? word = Console.ReadLine();
            Int16 count = new();

            for (int i = 0 , j = 0; i < text1.Length; i++)
            {
                if (text1[i] == word[j])
                {
                    if (j == word.Length-1)
                    {
                        for (int c = i - j; c <= i; c++)
                            text1[c] = '*';
                        count++;
                        j = 0;
                    }
                    else j++;
                }
                else
                {
                    i = i - j;
                    j = 0;
                }
            }
            Console.WriteLine(text1);
        }

        public static void Main()
        {
           task1();
           //task2();
           //task3();
           //task4();
           //task5();
           //task6();
           //task7();
        }
    }
}