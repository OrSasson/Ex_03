using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class GarageUIUtils
    {
        private static PropertyValidator<int> m_IntValidator = new IntValidator();
        private static PropertyValidator<float> m_FloatValidator = new FloatValidator();
        const int k_VehicleStatusOptionsNumber = 3;
        const int k_VehicleTypeOptionsNumber = 5;
        const int k_CarColorOptionsNumber = 4;
        const int k_CarDoorsOptionsNumber = 4;
        const int k_MotorcycleLicenseOptionsNumber = 4;
        const int k_FuleTypesOptionsNumber = 4;
        internal const string k_VehicleStatusOptions = @"Please chose the vehicle status:
1.Vehicle is under repair.
2.Vehicle is repaired.
3.Paid.";
        internal const string k_VehicleTypeOptions = @"Please chose the vehicle type: 
1.FuelCar.
2.ElectricCar.
3.FuelMotorcycle.
4.ElectricMotorcycle.
5.FuelTruck.";
        internal const string k_CarColorOptions = @"Please chose the vehicle color : 
1.Green.
2.Silver.
3.White.
4.Black.";
        internal const string k_CarDoorsOptions = @"Please chose the number of doors in customer's car:
1.Two doors.
2.Three doors.
3.Four doors.
4.Five doors.";
        internal const string k_MotorcycleLicenseOptions = @"Please chose the motorcycle license type:
1.A1.
2.B1.
3.AA.
4.BB.";
        internal const string k_FueLTypesOptions = @"Please chose the vehicle status:
1.Soler.
2.Octan95.
3.Octan96.
4.Octan98.";

        internal static eFuelType getFuelTypeFromUser()
        {
            string fuelTypeStr = string.Empty;

            fuelTypeStr = GetVehicleProperty(k_FueLTypesOptions, k_FuleTypesOptionsNumber);

            return ((eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeStr));
        }

        internal static eVehicleStatus getVehicleStatus()
        {
            string vehicleStatusStr = string.Empty;

            vehicleStatusStr = GetVehicleProperty(k_VehicleStatusOptions, k_VehicleStatusOptionsNumber);

            return (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), vehicleStatusStr);
        }

        internal static eVehicleType GetVehicleType()
        {
            string vehicleTypeStr = String.Empty;

            vehicleTypeStr = GetVehicleProperty(k_VehicleTypeOptions, k_VehicleTypeOptionsNumber);

            return (eVehicleType)Enum.Parse(typeof(eVehicleType), vehicleTypeStr);
        }

        internal static string GetStringFromUser(string i_RequiredInfo)
        {
            string userStr = string.Empty;

            Console.WriteLine("{0}", i_RequiredInfo);
            userStr = Console.ReadLine();

            return userStr;
        }

        internal static string getVehicleModelName()
        {
            return GetStringFromUser("Please enter the vehicle's model name : ");
        }

        internal static string getVehicleLicenseNumber()
        {
            return GetStringFromUser("Please enter the vehicle license plate number: ");
        }

        internal static string getWheelManufacturerName()
        {
            return GetStringFromUser("Please enter the Wheel manufactorer name : ");
        }

        internal static string getVehicleOwnerName()
        {
            return GetStringFromUser("Please enter the vehicle owner name : ");
        }

        internal static string getVehicleOwnerPhoneNum()
        {
            return GetStringFromUser("Please enter the vehicle owner phone number : ");
        }

        internal static float getCurrentTiersAirPressure()
        {
            //we need to get the max wheel air pressure here
            Console.WriteLine("Enter Vehicle Owner Name");
            string currentAirPressure = Console.ReadLine();

            return float.Parse(currentAirPressure);
        }

        internal static float getBatteryAmountToCharge(Vehicle vehicleToCharge)
        {
            //we need to get the max wheel air pressure here
            Console.WriteLine("Enter amount you would like to charge");
            string currentAirPressure = Console.ReadLine();

            return float.Parse(currentAirPressure);
        }

        //Car uninque properties
        internal static string getNumberOfDoorsInCar()
        {
            string doorsNumStr = string.Empty;
            int doorsNum;

            doorsNum = m_IntValidator.GetPropertyValueFromUser(k_CarDoorsOptions, out doorsNum);
            doorsNumStr = doorsNum.ToString();

            return ((eNumDoorsInCar)Enum.Parse(typeof(eNumDoorsInCar), doorsNumStr)).ToString();
        }

        internal static string getCarColor()
        {
            string carColorStr = string.Empty;

            carColorStr = GetVehicleProperty(k_CarColorOptions, k_CarColorOptionsNumber);

            return ((eCarColor)Enum.Parse(typeof(eCarColor), carColorStr)).ToString();
        }

        //Motorcycle unique properties
        internal static string getMotorcycleLicenseType()
        {
            string licenseTypeStr = string.Empty;

            licenseTypeStr = GetVehicleProperty(k_MotorcycleLicenseOptions, k_MotorcycleLicenseOptionsNumber);

            return ((eMotorcylceLicenseType)Enum.Parse(typeof(eMotorcylceLicenseType), licenseTypeStr)).ToString();
        }

        internal static string getMotorcycleEngineVolume()
        {
            int engineVolume;
            string engineVolumeStr;

            m_IntValidator.GetPropertyValueFromUser("Please enter the Motorcycle engine volume : ", out engineVolume);
            engineVolumeStr = engineVolume.ToString();

            return engineVolumeStr;
        }

        //Truck uninque properties
        internal static string DoesContainsHazardousMaterials()
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

            return doesContainsHazardousMaterials.ToString();
        }

        internal static string GetTruckMaxLoadingWeight()
        {
            float maxWeight;
            string maxWeightStr = string.Empty;

            m_FloatValidator.TryParse("Please enter the truck's Maximum loading weight:", out maxWeight);
            maxWeightStr = maxWeight.ToString();

            return maxWeightStr;
        }

        //check if this method is unnecessary
        internal static string GetVehicleProperty(string i_UserOptionsSet, int i_UserOptionsNumber)
        {
            int userPropertyValue;
            string userPropertyStr = string.Empty;

            do
            {
                m_IntValidator.GetPropertyValueFromUser(i_UserOptionsSet, out userPropertyValue);
                userPropertyStr = userPropertyValue.ToString();

            } while (userPropertyValue < 1 || userPropertyValue > i_UserOptionsNumber);

            return userPropertyStr;
        }
    }
}
