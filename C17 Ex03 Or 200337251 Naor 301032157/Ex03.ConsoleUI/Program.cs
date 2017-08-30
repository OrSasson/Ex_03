using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    //$Or - All enums should be changed to contain the class they belong to.
    class Program
    {
        public static void Main()
        {
            ConsoleUI GarageUI = new ConsoleUI();

            GarageUI.DisplayUserOptions();
         
            
            
            //try
            //{
            //    methodToThrowEx();
            //}
            //catch (ValueOutOfRangeExeception)
            //{
            //    Console.WriteLine("not parsable");
            //}

            
        }

        //public static void methodToThrowEx()
        //{
        //    int x = 0;
        //    string str = "600";
        //    x = int.Parse(str);

        //    if (x > 40)
        //    {
        //        throw new ValueOutOfRangeExeception();
        //    }

        //    Console.WriteLine("I am the line after the exce[tion");
        //}
    }
}