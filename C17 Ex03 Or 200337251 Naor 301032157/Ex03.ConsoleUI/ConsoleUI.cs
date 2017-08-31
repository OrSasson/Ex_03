using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        private PropertyParcer<int> m_IntParcer;
        private PropertyParcer<float> m_FloatParcer;

        public ConsoleUI()
        {
            m_IntParcer = new IntParcer();
            m_FloatParcer = new FloatParcer();
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


        
        public void UserOptions()
        {
            int userChoice;
            string userChoiceStr;

            Console.WriteLine(@"Please chose the required service:
1.{0}.
2.{1}.
3.{2}.
4.{3}.
5.{4}.
6.{5}.
7.{6}.",
"Assign new vehicle for repair (License plate)",
"View license plates filtered by status (Status to view)",
"Change vehicle status (License plate)",
"Inflate wheels in vehicle to max pressure (license plate, )",
"Refule fuel type vehicle (License plate, Fuel type, Liters to add)",
"Recharge Electric type vehicle (License plate, Minutes to charge)",
"View vehicle full detailes (License plate)");
            userChoiceStr = Console.ReadLine();


        }

        
        public void x()
        {
            //option 1 
            //Get license plate number from user
            //Check if license exist - bool
            // if yes - change status
            // else - get data from user
            //       1.Get vehicle type
            //       2.check vehicle type 5 times for each vehicle type
            //       3.get vehicle properties by vehicly type (seperate methods for each type)
            //       4.set wheels - logic 
            //       5.get vehicle model
            //       6.get vehicle license plate number
            //       7.get owner name
            //       8.get owner phone number
            //       9.
            //       10.
        }

        public int GetVehicleProperty(string i_UserOptionsSet)
        {
            //this are the required strings

            //doors options string 
            //      @"Please chose the number of doors in customer's car:
            //1.Two doors
            //2.Three doors
            //3.Four doors
            //4.Five doors"

            //vehicle type string
            //      @"Please chose the vehicle type: 
            //1.FuelCar
            //2.ElectricCar
            //3.FuelMotorcycle
            //4.ElectricMotorcycle
            //5.FuelTruck."

            //Motorcycle license type string
            //      @"Please chose the motorcycle license type:
            //1.A1
            //2.B1
            //3.AA
            //4.BB"
            int userProperyValue;

            m_IntParcer.GetVehicleProperty(i_UserOptionsSet, out userProperyValue);

            return userProperyValue;
        }

        public bool DoesContainsHazardousMaterials()
        {
            string doesContainsStr = string.Empty;
            bool doesContainsHazardousMaterials;

            do
            {
                Console.WriteLine("Does the Truck contains Hazardous Materials ? (Y/N)");
                doesContainsStr = Console.ReadLine();
            }
            while (doesContainsStr != "Y" && doesContainsStr != "y" && doesContainsStr != "N" && doesContainsStr != "n");

            if (doesContainsStr == "Y" || doesContainsStr != "y")
            {
                doesContainsHazardousMaterials = true;
            }
            else
            {
                doesContainsHazardousMaterials = false;
            }

            return doesContainsHazardousMaterials;
        }

        public float GetTruckMaxLoadingWeight()
        {
            float maxWeight;

            m_FloatParcer.TryParce("Please enter the truck's Maximum loading weight:", out maxWeight);

            return maxWeight;
        }

        public string GetStringFromUser(string i_RequiredInfo)
        {
            //1.vehicle model name string
            //2.vehicle owner name string
            //3.owner phone number string
            //4.wheel manufactorer string
            string userStr = string.Empty;

            Console.WriteLine("Please enter the {0}: ", i_RequiredInfo);
            userStr = Console.ReadLine();

            return userStr;
        }
    }
}
