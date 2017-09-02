using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class GarageUIUtils
    {
        internal static eVehicleType GetVehicleType()
        {
            string vehicleTypeStr = Console.ReadLine();

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
    }
}
