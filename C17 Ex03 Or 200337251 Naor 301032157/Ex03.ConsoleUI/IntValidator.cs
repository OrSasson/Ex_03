using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class IntValidator : PropertyValidator<int>
    {
        public override int GetPropertyValueFromUser(string i_UserOptionsSet, out int o_UserChoice)
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

        public override bool TryParse(string i_Source, out int o_Target)
        {
            return int.TryParse(i_Source, out o_Target);   
        }
    }
}