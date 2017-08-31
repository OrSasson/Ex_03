using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public abstract class PropertyParcer<T>
    {
        public T GetVehicleProperty(string i_UserOptionsSet, out T o_UserChice)
        {
            string userChoiceStr = string.Empty;
            bool tryParseSucceed = true;

            do
            {
                Console.WriteLine("{0}", i_UserOptionsSet);
                userChoiceStr = Console.ReadLine();
                tryParseSucceed = TryParce(userChoiceStr, out o_UserChice);
                //tryParseSucceed = int.TryParse(userChoiceStr, out userChoice);
            }
            while (!tryParseSucceed);

            Console.WriteLine();

            return o_UserChice;
        }

        public abstract bool TryParce(string i_Source, out T o_Target);
    }
}
