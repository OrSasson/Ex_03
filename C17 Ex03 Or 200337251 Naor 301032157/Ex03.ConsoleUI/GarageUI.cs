using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        
        public GarageUI()
        {
            
            //loadGarageSystem(); // Load?
        }

        public static void DisplayUserOptions()
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
"Inflate wheels in vehicle to max pressure (license plate)",
"Refule fuel type vehicle (License plate, Fuel type, Liters to add)",
"Recharge Electric type vehicle (License plate, Minutes to charge)",
"View vehicle full detailes (License plate)");
        }

        public void GarageMenu()
        {
            DisplayUserOptions();
            loadGarageSystem();

        }

        private void loadGarageSystem()
        {
            string choice = Console.ReadLine();
            eGarageSystemServices GarageSystemService = eGarageSystemServices.NoSelection;

            try
            {
                GarageSystemService = (eGarageSystemServices)Enum.Parse(typeof(eGarageSystemServices), choice);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input, please chose one option from the menu.");
            }

            Console.WriteLine("You chose option number {0}. ", choice);

            string LicenseNumber = GarageUIUtils.getVehicleLicenseNumber();

            switch (GarageSystemService)
            {
                case eGarageSystemServices.AssignVehicleToRepair: // Option 1 in menu

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

                case eGarageSystemServices.ViewVehiclesPlateNumbersByStatus: // Option 2 in menu
                    bool v_includeFilter = true;
                    eVehicleStatus vehicleStatus = eVehicleStatus.NotDetermined;

                    vehicleStatus = GarageUIUtils.getVehicleStatus();
                    GarageServices.GetVehiclesListInGarage(vehicleStatus, v_includeFilter);
                    //Without filter.
                    //GarageServices.GetVehiclesListInGarage(vehicleStatus, !v_includeFilter);
                    break;

                case eGarageSystemServices.ChangeVehicleStatus: // Option 3 in menu
                    Vehicle vehicleToChangeStatus = null;
                    eVehicleStatus newVehicleStatus = GarageUIUtils.getVehicleStatus();
                    if (GarageServices.tryGetVehicleByLicense(GarageUIUtils.getVehicleLicenseNumber(), out vehicleToChangeStatus))
                    {
                        GarageServices.ChangeVehicleStatus(vehicleToChangeStatus, newVehicleStatus);
                    }
                    break;

                case eGarageSystemServices.InflateVehicleWheelsToMax: // Option 4 in menu
                    Vehicle vehicleToInflateWheels = null;
                    string vehicleToInflateLicenseNumStr = GarageUIUtils.getVehicleLicenseNumber();
                    GarageServices.tryGetVehicleByLicense(vehicleToInflateLicenseNumStr, out vehicleToInflateWheels);
                    break;

                case eGarageSystemServices.RefuelFuelBasedVehicle: // Option 5 in menu
                    Vehicle vehicleToFuel = null;
                    string vehicleToFuelStr = GarageUIUtils.getVehicleLicenseNumber();
                    float fuelToadd = float.Parse(Console.ReadLine());

                    if (GarageServices.tryGetVehicleByLicense(vehicleToFuelStr, out vehicleToFuel))
                    {
                        // GarageServices.AddFuel(vehicleToFuelStr, fuelToadd, vehicleToFuel);
                    }
                    else
                    {
                        Console.WriteLine("blabla...");
                    }
                    break;

                case eGarageSystemServices.RechargeElectricBasedVehicle: // Option 6 in menu
                    Vehicle vehicleToRecharge = null;
                    string vehicleToRechargeStr = GarageUIUtils.getVehicleLicenseNumber();
                    GarageServices.tryGetVehicleByLicense(vehicleToRechargeStr, out vehicleToRecharge);
                    float energyToadd = float.Parse(Console.ReadLine());
                    // Need to Add - Get FuelType, Get bla bla...
                    GarageServices.ChargeBattery(vehicleToRechargeStr, energyToadd, vehicleToRecharge);
                    break;

                case eGarageSystemServices.ViewVehicleInfo: // Option 7 in menu
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
    }
}
