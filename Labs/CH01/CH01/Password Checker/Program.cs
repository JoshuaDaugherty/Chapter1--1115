using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter password again: ");
            string passwordC = Console.ReadLine();

            if (!password.Equals(string.Empty))
            {
                if (!passwordC.Equals(string.Empty))
                {
                    if(password.Length >= 6 && passwordC.Length >= 7)
                    {
                        if (password.Equals(passwordC))
                        {
                            Console.WriteLine("Passwords Match");
                        }
                        else
                        {
                            Console.WriteLine("Passwords dont Match");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter 6 or more characters!");
                    }
                   

                    if (password.Equals(passwordC))
                    {
                        Console.WriteLine("Passwords Match");
                    }
                    else
                    {
                        Console.WriteLine("Passwords dont Match");
                    }


                }
               
                        


                else
                {
                    Console.WriteLine("Please enter a password conformation.");
                }
               
            }
            else
            {
                Console.WriteLine("Please enter a password.");
            }

            Console.ReadLine();
        }
    }
}
