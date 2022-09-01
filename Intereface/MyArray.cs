using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class MyArray: ICalc ,ICalc2 ,IOutput2
    {
        public MyArray(params Int32[] numbers) {
            this.Array = new Int32[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                this[i] = numbers[i];
        }

        public void Add(params Int32[] numbers)
        {
                var tmp = this.Array;
                this.Array = new Int32[tmp.Length + numbers.Length];
            for (int i = 0; i < tmp.Length; i++)
                this.Array[i] = tmp[i];
            for (int i = tmp.Length; i < tmp.Length + numbers.Length; i++)
                this.Array[i] = numbers[i - tmp.Length];
        }

        public void Add(Int32 index , params Int32[] numbers)
        {
            var tmp = this.Array;
            this.Array = new Int32[tmp.Length + numbers.Length];
            for (int i = 0 , j = 0; i < tmp.Length; i++){
                if(i == index)
                {
                    for (int c = 0; c < numbers.Length; c++)
                        this.Array[j++] = numbers[c];
                }
                this.Array[j++] = tmp[i];
            }
        }
        public void DeleteElement(UInt32 index)
        {
            if(index < this.Length)
            {
                var tmp = this.Array;
                this.Array = new Int32[tmp.Length-1];
                for (int i = 0 , j = 0; i < tmp.Length; i++)
                {
                    if (i != index) this.Array[j++] = tmp[i];
                }
            }
        }

        #region Sort
        public void Sort() => Quicksort(0, this.Array.Length-1, Array);
        private void Quicksort(Int32 min, Int32 max, Int32[] Array)
        {
            if (min > max) return;
            Int32 quick_number = quick(min , max , Array);
            Quicksort(quick_number+1 , max , Array);
            Quicksort(min, quick_number-1, Array);
        }
        private Int32 quick(Int32 min, Int32 max, Int32[] Array)
        {
            Int32 pivar = min-1;
            for (int i = min; i < max; i++)
                if (this.Array[i] < this.Array[max]) Swap(ref this.Array[++pivar] ,ref  this.Array[i]);

            Swap(ref Array[++pivar], ref Array[max]);
            return pivar;
        }
        private void Swap(ref Int32 a , ref Int32 b) {
            Int32 c = a;
            a = b;
            b = c;
        }

        public void SortShell()
        {
            Int32 step = this.Length / 2;
            while(step > 0)
            {
                for (int i = step; i < this.Length; i++)
                {
                    Int32 j = i;
                    while (j >= step && this.Array[j] < this.Array[j - step])
                    {
                        Swap(ref this.Array[j], ref this.Array[j - step]);
                        j -= step;
                    }
                }
                step /= 2; 
            }
        }
        #endregion
        public int Less(int valueToCompare)
        {
            Int32 count = new();
            for (int i = 0; i < this.Array.Length; i++)
                if (valueToCompare > this.Array[i]) count++;
            return count;
        }

        public int Greater(int valueToCompare)
        {
            Int32 count = new();
            for (int i = 0; i < this.Array.Length; i++)
                if (valueToCompare < this.Array[i]) count++;
            return count;
        }

        public void ShowEven()
        {
            for (int i = 0; i < this.Array.Length; i++)
                if (this.Array[i] % 2 == 0) Console.Write($"{Array[i]} ");
            Console.WriteLine();
        }

        public void ShowOdd()
        {
            for (int i = 0; i < this.Array.Length; i++)
                if (this.Array[i] % 2 != 0) Console.Write($"{Array[i]} ");
            Console.WriteLine();
        }

        public int CountDistinct()
        {
            Int32 count = new();
            SByte unigue = new();

            for (int i = 0; i < this.Array.Length; i++)
            {
                for (int j = 0; j < this.Array.Length; j++)
                {
                    if (this.Array[i] == this.Array[j])
                    {
                        unigue++;
                        if (unigue == 2) break;
                    }
                }
                if (unigue == 1) count++;
                unigue = 0;
            }
            return count;
        }

        public int EqualToValue(int valueToCompare)
        {
            Int32 count = new();
            for (int i = 0; i < this.Array.Length; i++)
                if (valueToCompare == this.Array[i]) count++;
            return count;
        }

        private Int32[] Array;
        public Int32 Length{ get => Array.Length; }
        public Int32 this[Int32 index]
        {
            get => this.Array[index];
            set
            {
                if (this.Length > index) this.Array[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }
    }
}
