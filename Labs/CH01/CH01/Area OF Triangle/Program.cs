using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_OF_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = ReadInt("Enter width: ");
            int height = ReadInt("Enter height: ");

            Console.WriteLine($"The area is {CalcArea(width, height)}");

            Console.ReadLine();
        }

        static int CalcArea(int width, int height)
        {
            return (width * height) / 2;
        }

        static int ReadInt(string message) 
        {
            Console.WriteLine($"Enter {message}");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
