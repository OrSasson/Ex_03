using System;

namespace Ex03.ConsoleUI
{
    public abstract class PropertyValidator<T>
    {
        public T GetPropertyValueFromUser(string i_UserOptionsSet, out T o_UserChoice)
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