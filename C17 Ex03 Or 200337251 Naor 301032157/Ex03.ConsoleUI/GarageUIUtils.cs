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
        const string k_VehicleStatusOptions = @"Please chose the vehicle status:
1.Vehicle is under repair.
2.Vehicle is repaired.
3.Paid.";
        const string k_VehicleTypeOptions = @"Please chose the vehicle type: 
1.FuelCar.
2.ElectricCar.
3.FuelMotorcycle.
4.ElectricMotorcycle.
5.FuelTruck.";
        const string k_CarColorOptions = @"Please chose the vehicle color : 
1.Green.
2.Silver.
3.White.
4.Black.";
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

        internal static eVehicleStatus getVehicleStatus()
        {
            string vehicleStatusStr = string.Empty;
            int vehicleStatus;

            vehicleStatus = m_IntValidator.GetVehicleProperty(k_VehicleStatusOptions, out vehicleStatus);
            vehicleStatusStr = vehicleStatus.ToString();

            return (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), vehicleStatusStr);
        }

        internal static eVehicleType GetVehicleType()
        {
            string vehicleTypeStr = String.Empty;
            int vehicleType;

            vehicleType = m_IntValidator.GetVehicleProperty(k_VehicleTypeOptions, out vehicleType);
            vehicleTypeStr = vehicleType.ToString();

            return (eVehicleType)Enum.Parse(typeof(eVehicleType), vehicleTypeStr);
        }

        //string properties
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

        //Car uninque properties
        internal static eNumDoorsInCar getNumberOfDoorsInCar()
        {
            string doorsNumStr = string.Empty;
            int doorsNum;

            doorsNum = m_IntValidator.GetVehicleProperty(k_CarDoorsOptions, out doorsNum);
            doorsNumStr = doorsNum.ToString();

            return (eNumDoorsInCar)Enum.Parse(typeof(eNumDoorsInCar), doorsNumStr);
        }

        internal static eCarColor getCarColor()
        {
            string carColorStr = string.Empty;
            int carColor;

            carColor = m_IntValidator.GetVehicleProperty(k_CarColorOptions, out carColor);
            carColorStr = carColor.ToString();

            return (eCarColor)Enum.Parse(typeof(eCarColor), carColorStr);
        }

        //Motorcycle unique properties
        internal static eMotorcycleLicenseType getMotorcycleLicenseType(Type i_Type)
        {
            string licenseType = string.Empty;
            int doorsNum;

            doorsNum = m_IntValidator.GetVehicleProperty(k_MotorcycleLicenseOptions, out doorsNum);
            licenseType = doorsNum.ToString();

            return (eMotorcycleLicenseType)Enum.Parse(typeof(eMotorcycleLicenseType), licenseType);
        }

        internal static int getMotorcycleEngineVolume()
        {
            int engineVolume;

            engineVolume = GetVehicleProperty("Please enter the Motorcycle engine volume : ");

            return engineVolume;
        }

        //Truck uninque properties
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

            m_FloatValidator.TryParse("Please enter the truck's Maximum loading weight:", out maxWeight);

            return maxWeight;
        }

        //check if this method is unnecessary
        internal static int GetVehicleProperty(string i_UserOptionsSet)
        {
            int userProperyValue;

            m_IntValidator.GetVehicleProperty(i_UserOptionsSet, out userProperyValue);

            return userProperyValue;
        }
    }
}
