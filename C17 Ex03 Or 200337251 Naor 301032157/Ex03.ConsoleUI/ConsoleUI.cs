using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        public ConsoleUI()
        {

        }

        public void DisplayUserOptions()
        {
            string choice = string.Empty;

            Console.WriteLine("Please enter your choice: ");
            choice = Console.ReadLine();
            Console.WriteLine("You chose option number 2.");
        }
    }
}
