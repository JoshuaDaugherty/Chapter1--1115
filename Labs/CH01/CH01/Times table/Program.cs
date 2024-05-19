using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Times_table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++) 
            {
                Console.WriteLine("{0} x {1} ={2}", i, number, i * number);
            }
            Console.ReadLine();
        }
    }
}
