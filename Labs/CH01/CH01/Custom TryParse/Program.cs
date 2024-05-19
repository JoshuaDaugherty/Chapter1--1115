using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_TryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            if (TryParse(Console.ReadLine(), out int result))
            {
                Console.WriteLine("YEY");
            }
            else
            {
                Console.WriteLine("oh no");
            }

            Console.ReadLine();
        }

        static bool TryParse(string input, out int result)
        {
            result = -1;

            try
            {
                result = Convert.ToInt32(input);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
    }
}
