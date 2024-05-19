using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_Int_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[]
            {
                0, -1, -2, -3, -4, -100
            };

            int result = SumOfNumbers(numbers);

            if (result > -1)
            {
                Console.WriteLine($"The total is: {result}");
            }
            else
            {
                Console.WriteLine("Cannot add up an empty array!");
            }

            if (SumOfNumbers(numbers, out int total))
            {
                Console.WriteLine($"The total is:{total}");
            }
            else
            {
                Console.WriteLine("Cannot add up an empty array!");
            }

            Console.ReadLine();
        }

        static int SumOfNumbers(int[] numbers)
        {
            if (numbers.Length > 0)
            {
                int total = 0;

                foreach (var item in numbers)
                {
                    total += item;
                }

                return total;
            }
            return  -1;
        }

        static bool SumOfNumbers(int[] numbers, out int total)
        {
            total = 0; 

            if (numbers.Length > 0)
            {
                foreach (var item in numbers)
                {
                    total += item;
                }

                return true;
            }

            return false;
        }
    }
}
