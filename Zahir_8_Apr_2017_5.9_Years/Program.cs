using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zahir_8_Apr_2017_5._5Years
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Option:");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            string option = Console.ReadLine();

            if (option == "1")
            {
                XmlProgram1.Task1();
            }
            else if (option == "2")
            {
                XMlProgram2.Task2();
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }
        }
    }
}
