using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageUIUtils
    {
        internal const int k_VehicleStatusOptionsNumber = 3;
        internal const int k_VehicleTypeOptionsNumber = 5;
        internal const int k_CarColorOptionsNumber = 4;
        internal const int k_CarDoorsOptionsNumber = 4;
        internal const int k_MotorcycleLicenseOptionsNumber = 4;
        internal const int k_FuleTypesOptionsNumber = 4;
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

        internal const string k_InputLicensePlate = "Please enter the vehicle license plate number: ";
        internal const string k_LincesCannotBeEmpty = "License Number cannot be empty!";
        internal const string k_EnterWheelManufacturerName = "Please enter the Wheel manufacturer name : ";
        internal const string k_EnterVehicleOwnerName = "Please enter the vehicle owner name : ";
        internal const string k_EnterVehicleOwnerPhoneNumber = "Please enter the vehicle owner phone number : ";
        internal const string k_EnterMotorcycleEngineVolume = "Please enter the Motorcycle engine volume : ";
        internal const string k_EnterAmountToAddFuel = "Enter amount you would like to charge";
        internal const string k_EnterMaxiumLoadingWeight = "Please enter the truck's Maximum loading weight:";
        internal const string k_EnterHazardousMaterialExistence = "Does the Truck contains Hazardous Materials ? (Y/N)";
        private static PropertyValidator<int> m_IntValidator = new IntValidator();
        private static PropertyValidator<float> m_FloatValidator = new FloatValidator();

        internal static eFuelType getFuelTypeFromUser()
        {
            string fuelTypeStr;

            fuelTypeStr = GetVehicleProperty(k_FueLTypesOptions, k_FuleTypesOptionsNumber);

            return (eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeStr);
        }

        internal static eVehicleStatus getVehicleStatus()
        {
            string vehicleStatusStr;

            vehicleStatusStr = GetVehicleProperty(k_VehicleStatusOptions, k_VehicleStatusOptionsNumber);

            return (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), vehicleStatusStr);
        }   

        internal static eVehicleType getVehicleType()
        {
            string vehicleTypeStr;

            vehicleTypeStr = GetVehicleProperty(k_VehicleTypeOptions, k_VehicleTypeOptionsNumber);

            return (eVehicleType)Enum.Parse(typeof(eVehicleType), vehicleTypeStr);
        }

        internal static string getStringFromUser(string i_RequiredInfo)
        {
            string userStr;

            Console.WriteLine("{0}", i_RequiredInfo);
            userStr = Console.ReadLine();

            return userStr;
        }

        internal static string getVehicleModelName()
        {
            return getStringFromUser("Please enter the vehicle's model name : ");
        }

        internal static string getVehicleLicenseNumber()
        {
            string licenseNumber = getStringFromUser(k_InputLicensePlate);

            while (licenseNumber == string.Empty)
            {
                Console.WriteLine(k_LincesCannotBeEmpty);
                licenseNumber = getStringFromUser(k_InputLicensePlate);
            }

            return licenseNumber;
        }

        internal static string getWheelManufacturerName()
        {
            return getStringFromUser("Please enter the Wheel manufacturer name : ");
        }

        internal static string getVehicleOwnerName()
        {
            return getStringFromUser("Please enter the vehicle owner name : ");
        }

        internal static string getVehicleOwnerPhoneNum()
        {
            return getStringFromUser(k_EnterVehicleOwnerPhoneNumber);
        }

        internal static float getBatteryAmountToCharge(Vehicle i_vehicleToCharge)
        {
            Console.WriteLine(k_EnterAmountToAddFuel);
            string amountToChargeStr = Console.ReadLine();

            return float.Parse(amountToChargeStr);
        }

        internal static string getNumberOfDoorsInCar()
        {
            string doorsNumStr;

            doorsNumStr = GetVehicleProperty(k_CarDoorsOptions, k_CarDoorsOptionsNumber);

            return ((eNumDoorsInCar)Enum.Parse(typeof(eNumDoorsInCar), doorsNumStr)).ToString();
        }

        internal static string getCarColor()
        {
            string carColorStr;

            carColorStr = GetVehicleProperty(k_CarColorOptions, k_CarColorOptionsNumber);

            return ((eCarColor)Enum.Parse(typeof(eCarColor), carColorStr)).ToString();
        }

        internal static string getMotorcycleLicenseType()
        {
            string licenseTypeStr;

            licenseTypeStr = GetVehicleProperty(k_MotorcycleLicenseOptions, k_MotorcycleLicenseOptionsNumber);

            return ((eMotorcylceLicenseType)Enum.Parse(typeof(eMotorcylceLicenseType), licenseTypeStr)).ToString();
        }

        internal static string getMotorcycleEngineVolume()
        {
            int engineVolume;
            string engineVolumeStr;

            m_IntValidator.GetPropertyValueFromUser(k_EnterMotorcycleEngineVolume, out engineVolume);
            engineVolumeStr = engineVolume.ToString();

            return engineVolumeStr;
        }

        internal static string DoesContainsHazardousMaterials()
        {
            string doesContainsStr = string.Empty;
            bool doesContainsHazardousMaterials;

            do
            {
                Console.WriteLine(k_EnterHazardousMaterialExistence);
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

            m_FloatValidator.TryParse(k_EnterMaxiumLoadingWeight, out maxWeight);
            maxWeightStr = maxWeight.ToString();

            return maxWeightStr;
        }

        internal static string GetVehicleProperty(string i_UserOptionsSet, int i_UserOptionsNumber)
        {
            int userPropertyValue;
            string userPropertyStr = string.Empty;

            do
            {
                m_IntValidator.GetPropertyValueFromUser(i_UserOptionsSet, out userPropertyValue);
                userPropertyStr = userPropertyValue.ToString();
            }
            while (userPropertyValue < 1 || userPropertyValue > i_UserOptionsNumber);

            return userPropertyStr;
        }
    }
}