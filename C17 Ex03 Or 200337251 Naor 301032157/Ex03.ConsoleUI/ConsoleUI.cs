using Ex03.GarageLogic;
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
            //$Or - Stupid Test...
            Console.WriteLine("Please enter your choice: ");
            choice = Console.ReadLine();
            Console.WriteLine("You chose option number 2.");

            eVehicleType vehicleType = eVehicleType.Car;
            string modelName = " Toyota";
            string licenceNumber = "12345";
            string wheelManfucaturerName = "Wrengler";
            string ownerName = " Moshiko";
            string ownerPhoneNum = "050-123456";

            // $Or - Add This code After You used your methods to get all the input.
            try
            {
                GarageServices.AddNewGarageEntry(vehicleType, modelName, licenceNumber, ownerName, ownerPhoneNum, wheelManfucaturerName);
            }
            // Is it even relevant to show this exception to user?
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
