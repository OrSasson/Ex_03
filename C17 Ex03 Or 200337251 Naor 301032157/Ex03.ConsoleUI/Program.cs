using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    //$Or - All enums should be changed to contain the class they belong to.
    // Public all over the place!!! see what can be done.
    // Inflate wheels should be with try catch when called.
    class Program
    {
        public static void Main()
        {
            GarageUI GarageUI = new GarageUI();
            GarageUI.GarageMenu();
        }
    }
}