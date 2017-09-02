using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class GarageUIUtils
    {
        private static PropertyParcer<int> m_IntParcer = new IntParcer();
        private static PropertyParcer<float> m_FloatParcer = new FloatParcer();
        const string k_VehicleTypeOptions = @"Please chose the vehicle type: 
1.FuelCar.
2.ElectricCar.
3.FuelMotorcycle.
4.ElectricMotorcycle.
5.FuelTruck.";
        const string k_CarDoorsOptions = @"Please chose the number of doors in customer's car:
1.Two doors.
2.Three doors.
3.Four doors.
4.Five doors.";
        const string k_MotorcycleLicenseOptions = @"Please chose the motorcycle license type:
1.A1.
2.B1.
3.AA.
4.BB.";

        internal static eVehicleType GetVehicleType()
        {
            string vehicleTypeStr = GetStringFromUser(k_VehicleTypeOptions);

            return (eVehicleType)Enum.Parse(typeof(eVehicleType), vehicleTypeStr);
        }
        
        internal static string getVehicleModelName()
        {
            Console.WriteLine("Enter Model Name");

            return Console.ReadLine();
        }
        
        internal static string getVehicleLicenseNumber()
        {
            Console.WriteLine("Enter License Number");

            return Console.ReadLine();
        }
        
        internal static string getWheelManufacturerName()
        {
            Console.WriteLine("Enter Wheels Manufacturer Name");

            return Console.ReadLine();
        }
        
        internal static string getVehicleOwnerName()
        {
            Console.WriteLine("Enter vehicle owner Name");

            return Console.ReadLine();
        }
        
        internal static string getVehicleOwnerPhoneNum()
        {
            Console.WriteLine("Enter vehicle owner phoneName");

            return Console.ReadLine();
        }

        internal static float getCurrentTiersAirPressure()
        {
            string currentAirPressure = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Owner Name");

            return float.Parse(currentAirPressure);
        }

        internal static eVehicleStatus getVehicleStatus()
        {
            string vehicleStatusStr = Console.ReadLine();

            return (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), vehicleStatusStr);
        }

        internal static int GetVehicleProperty(string i_UserOptionsSet)
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

        internal static bool DoesContainsHazardousMaterials()
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

        internal static float GetTruckMaxLoadingWeight()
        {
            float maxWeight;

            m_FloatParcer.TryParce("Please enter the truck's Maximum loading weight:", out maxWeight);

            return maxWeight;
        }

        public static string GetStringFromUser(string i_RequiredInfo)
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
