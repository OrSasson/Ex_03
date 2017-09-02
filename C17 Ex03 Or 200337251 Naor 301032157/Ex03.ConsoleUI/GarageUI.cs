using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        private PropertyParcer<int> m_IntParcer;
        private PropertyParcer<float> m_FloatParcer;

        public GarageUI()
        {
            m_IntParcer = new IntParcer();
            m_FloatParcer = new FloatParcer();
            loadGarageSystem(); // Load?
        }

        private void loadGarageSystem()
        {
            UserOptions();
            string choice = Console.ReadLine();
            Console.WriteLine("You chose option number {0}. ", choice);
            eGarageSystemServices GarageSystemService = eGarageSystemServices.NoSelection;

            // Add try catch here...
            GarageSystemService = (eGarageSystemServices)Enum.Parse(typeof(eGarageSystemServices), choice);

            string LicenseNumber = GarageUIUtils.getVehicleLicenseNumber();
            switch (GarageSystemService)
            { 
                case eGarageSystemServices.AssignVehicleToRepair:

                    Vehicle vehicleToAdd = null;
                    if (GarageServices.tryGetVehicleByLicense(LicenseNumber, out vehicleToAdd))
                    {
                        GarageServices.ChangeVehicleStatus(vehicleToAdd, eVehicleStatus.Repaired);
                    }
                    else
                    {
                        eVehicleType vehicleType = GarageUIUtils.GetVehicleType();
                        string modelName = GarageUIUtils.getVehicleModelName();
                        string licenseNumber = GarageUIUtils.getVehicleLicenseNumber();
                        string wheelManfucaturerName = GarageUIUtils.getWheelManufacturerName();
                        string ownerName = GarageUIUtils.getVehicleOwnerName();
                        string ownerPhoneNum = GarageUIUtils.getVehicleOwnerPhoneNum();
                        float wheelCurrentAirPressure = GarageUIUtils.getCurrentTiersAirPressure();

                        try
                        {
                            Dictionary<string, string> uniqueVehicleProperties = GetUniquePropertiesByVehicleType(vehicleType);
                            GarageServices.AddNewGarageEntry(vehicleType, modelName, licenseNumber, ownerName, ownerPhoneNum, wheelManfucaturerName, wheelCurrentAirPressure, uniqueVehicleProperties);
                        }
                        // Is it even relevant to show this exception to user?
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    break;

                case eGarageSystemServices.ViewVehiclesPlateNumbersByStatus:
                    bool v_includeFilter = true;
                    eVehicleStatus vehicleStatus = eVehicleStatus.NotDetermined;

                    vehicleStatus = GarageUIUtils.getVehicleStatus();
                    GarageServices.GetVehiclesListInGarage(vehicleStatus, v_includeFilter);
                    //Without filter.
                    //GarageServices.GetVehiclesListInGarage(vehicleStatus, !v_includeFilter);
                    break;

                case eGarageSystemServices.ChangeVehicleStatus:
                    Vehicle vehicleToChangeStatus = null;
                    eVehicleStatus newVehicleStatus = GarageUIUtils.getVehicleStatus();
                    if (GarageServices.tryGetVehicleByLicense(GarageUIUtils.getVehicleLicenseNumber(), out vehicleToChangeStatus))
                    {
                        GarageServices.ChangeVehicleStatus(vehicleToChangeStatus, newVehicleStatus);
                    }
                    break;

                case eGarageSystemServices.InflateVehicleWheelsToMax:
                    Vehicle vehicleToInflateWheels= null;
                    string vehicleToInflateLicenseNumStr = GarageUIUtils.getVehicleLicenseNumber();
                    GarageServices.tryGetVehicleByLicense(vehicleToInflateLicenseNumStr, out vehicleToInflateWheels);
                    break;

                case eGarageSystemServices.RefuelFuelBasedVehicle:
                    Vehicle vehicleToFuel = null;
                    string vehicleToFuelStr = GarageUIUtils.getVehicleLicenseNumber();
                    float fuelToadd = float.Parse(Console.ReadLine());
                   
                    if (GarageServices.tryGetVehicleByLicense(vehicleToFuelStr, out vehicleToFuel))
                    {
                       // GarageServices.AddFuel(vehicleToFuelStr, fuelToadd,vehicleToFuel);
                    }
                    else
                    {
                        Console.WriteLine("blabla...");
                    } 
                    
                    break;

                case eGarageSystemServices.RechargeElectricBasedVehicle:
                    Vehicle vehicleToRecharge = null;
                    string vehicleToRechargeStr = GarageUIUtils.getVehicleLicenseNumber();
                    GarageServices.tryGetVehicleByLicense(vehicleToRechargeStr, out vehicleToRecharge);
                    float energyToadd = float.Parse(Console.ReadLine());
                    // Need to Add - Get FuelType, Get bla bla...
                    GarageServices.ChargeBattery(vehicleToRechargeStr, energyToadd, vehicleToRecharge);
                    break;

                case eGarageSystemServices.ViewVehicleInfo:
                    Vehicle vehicleToShowInfo = null;
                    string vehicleToShowInfoStr = GarageUIUtils.getVehicleLicenseNumber();
                    GarageServices.tryGetVehicleByLicense(vehicleToShowInfoStr, out vehicleToShowInfo);
                    GarageServices.showGarageEntryData(vehicleToShowInfo);
                    break;
                default:
                    break;
            }
        }
        private Dictionary<string, string> GetUniquePropertiesByVehicleType(eVehicleType vehicleType)
        {
            Dictionary<string, string> uniqueVehicleProperties = new Dictionary<string, string>();
            switch (vehicleType)
            {
                case eVehicleType.Car:
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyColor, GetStringFromUser(Console.ReadLine()));
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyNumOfDoors, GetStringFromUser(Console.ReadLine()));
                    break;
                case eVehicleType.Motorcycle:
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyEngineVolume, GetStringFromUser(Console.ReadLine()));
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyLicenseType, GetStringFromUser(Console.ReadLine()));
                    break;
                case eVehicleType.Truck:
                    uniqueVehicleProperties.Add(GarageConstants.k_CarryigHazardousMaterial, GetStringFromUser(Console.ReadLine()));
                    uniqueVehicleProperties.Add(GarageConstants.k_MaxLoadingWeight, GetStringFromUser(Console.ReadLine()));
                    break;
            }
            return uniqueVehicleProperties;
            }

        public static void UserOptions()
        {
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
        }

        
        //public void x()
        //{
        //    //option 1 
        //    //Get license plate number from user
        //    //Check if license exist - bool
        //    // if yes - change status
        //    // else - get data from user
        //    //       1.Get vehicle type
        //    //       2.check vehicle type 5 times for each vehicle type
        //    //       3.get vehicle properties by vehicly type (seperate methods for each type)
        //    //       4.set wheels - logic 
        //    //       5.get vehicle model
        //    //       6.get vehicle license plate number
        //    //       7.get owner name
        //    //       8.get owner phone number
        //    //       9.
        //    //       10.
        //}

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
