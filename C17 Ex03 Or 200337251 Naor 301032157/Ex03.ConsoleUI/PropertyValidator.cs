using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    // change from C to S in parcer
    public abstract class PropertyValidator<T>
    {
        //const bool v_WithRestriction = true;

        public virtual T GetVehicleProperty(string i_UserOptionsSet, out T o_UserChoice)
        {
            string userChoiceStr = string.Empty;
            bool tryParseSucceed = true;
        
            do
            {
                Console.WriteLine("{0}", i_UserOptionsSet);
                userChoiceStr = Console.ReadLine();
                tryParseSucceed = TryParse(userChoiceStr, out o_UserChoice);
            }
            while (!tryParseSucceed);
        
            return o_UserChoice;
        }

        public abstract bool TryParse(string i_Source, out T o_Target);
    }
}
