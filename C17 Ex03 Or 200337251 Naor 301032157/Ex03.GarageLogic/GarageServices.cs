using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class GarageServices
    {

        private static Dictionary<Vehicle, CustomerData> s_GarageEntries = new Dictionary<Vehicle, CustomerData>();

        //Menu Option 1 - Add New Vehicle (chainging status follows).
        // Still need to make sub methods.
        public static void AddNewGarageEntry(eVehicleType i_VehicleType, string i_ModelName, string i_LicenceNumber, string i_WheelManfucaturerName, string i_OwnerName, string i_OwnerPhoneNum, float i_WheelCurrentAirPressure, Dictionary<string, string> uniqueVehicleProperties)
        {
            

            Vehicle vehicleToAdd = VehicleFactory.CreateVehicle((int)i_VehicleType, i_ModelName, i_LicenceNumber);
            vehicleToAdd.SetWheels(i_WheelManfucaturerName, i_WheelCurrentAirPressure);
            vehicleToAdd.InitUniqueVehicleProperties(uniqueVehicleProperties);

            CustomerData vehicleCustomerData = new CustomerData(i_OwnerName, i_OwnerPhoneNum);

            s_GarageEntries.Add(vehicleToAdd, vehicleCustomerData);
        }

        //Menu Option 2 - Display vehicles List.
        public static List<string> GetVehiclesListInGarage(eVehicleStatus i_vehicleStatusFilter, bool i_IncludeFiltering)
        {
            List<string> vehiclesList = new List<string>();

            foreach (KeyValuePair<Vehicle, CustomerData> garageEntry in s_GarageEntries)
            {
                if (i_IncludeFiltering && garageEntry.Value.VehicleStatus == i_vehicleStatusFilter)
                {
                    vehiclesList.Add(garageEntry.Key.LicenseNumber);
                }
            }

            return vehiclesList;
        }

        //Menu Option 3 - Change vehicle's Status.
        public static void ChangeVehicleStatus(Vehicle i_VehicleToChange, eVehicleStatus i_NewVehicleStatus)
        {
            CustomerData customerData;

            s_GarageEntries.TryGetValue(i_VehicleToChange, out customerData);
            customerData.VehicleStatus = i_NewVehicleStatus;
        }

        //Menu Option 4 - Inflate Wheels to max.
        public static void InflateVehicleWheelsToMax(Vehicle vehicle)
        {
            vehicle.inflateAllWheelsToMax();
        }

        //Menu Option 5 - Add Fuel to a Vehicle that runs on Fuel.
        // Needs Refactoring, less params and reuse code in method.
        public static void AddFuel(string i_LicenceNumber, float i_EnergyToAdd, int i_FuelType, Vehicle i_Vehicle)
        {
            Engine vehicleEngineType = i_Vehicle.Engine;
            FuelEngine fuelEngine = vehicleEngineType as FuelEngine;
            FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)i_FuelType;

            if (fuelEngine.FuelType != fuelType)
            {
                throw new ArgumentException(string.Format("Invalid Fuel Type! This vehicle runs on {0}", fuelEngine.FuelType));
            }
            else
            {
                (vehicleEngineType as FuelEngine).AddEnergyToVehicle(i_EnergyToAdd);
            }
        }

        //Menu Option 6 - Add Fuel to a Vehicle that runs on Fuel.
        // Needs Refactoring, less params and reuse code in method.
        public static void ChargeBattery(string i_LicenceNumber, float i_EnergyToAdd, Vehicle i_Vehicle)
        {
            Engine vehicleEngineType = i_Vehicle.Engine;
            (vehicleEngineType as ElectricEngine).AddEnergyToVehicle(i_EnergyToAdd);
        }

        //Menu Option 7 - Display Full statistics of the Garage entry.
        public static string showGarageEntryData(Vehicle i_Vehicle)
        {
            return s_GarageEntries[i_Vehicle].ToString() + i_Vehicle.ToString();
        }

        // Utitlity Function. Needed for most options in menu.
        public static bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool exists = false;

            foreach (Vehicle vehicle in s_GarageEntries.Keys)
            {
                if (i_LicenseNumber == vehicle.LicenseNumber)
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        public static bool tryGetVehicleByLicense(string i_licenseNumer, out Vehicle o_Vehicle)
        {
            bool exists = false;
            o_Vehicle = null;

            foreach (Vehicle vehicle in s_GarageEntries.Keys)
            {
                if (i_licenseNumer == vehicle.LicenseNumber)
                {
                    exists = true;
                    o_Vehicle = vehicle;
                    break;
                }
            }
            return exists;
        }

        //public static bool IsVehicleNotInGarage(string i_LicenceNumber)
        //{
        //    bool exists = false;
        //    foreach (Vehicle currentVehicle in s_GarageEntries.Keys)
        //    {
        //        if (i_LicenceNumber == currentVehicle.LicenseNumber)
        //        {
        //            exists = true;
        //            break;
        //        }
        //    }

        //    return exists;
        //}
    }

}


