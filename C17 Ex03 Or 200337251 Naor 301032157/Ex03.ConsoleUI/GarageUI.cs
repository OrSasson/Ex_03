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

        private static void displayUserOptions()
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

        private void GarageMenu()
        {
           
            loadGarageSystem();

        }

        private void loadGarageSystem()
        {
            while (true)
            {
                try
                {
                    displayUserOptions();
                    string choice = getAndValidateUserMenuSelection();

                    //eGarageServicesMenuOptions GarageSystemService = eGarageServicesMenuOptions.NoSelection;
                    eGarageServicesMenuOptions GarageSystemService = (eGarageServicesMenuOptions)Enum.Parse(typeof(eGarageServicesMenuOptions), choice);

                    Console.WriteLine("You chose option number {0}. ", choice);

                    switch (GarageSystemService)
                    {
                        case eGarageServicesMenuOptions.AssignVehicleToRepair: // Option 1 in menu

                            addVehicleToGarage();
                            break;

                        case eGarageServicesMenuOptions.ViewVehiclesPlateNumbersByStatus: // Option 2 in menu
                            displayVehicleList();
                            break;

                        case eGarageServicesMenuOptions.ChangeVehicleStatus: // Option 3 in menu
                            ChangeVehicleStatus();
                            break;

                        case eGarageServicesMenuOptions.InflateVehicleWheelsToMax: // Option 4 in menu
                            InflateWheelsToMax();
                            break;

                        case eGarageServicesMenuOptions.RefuelFuelBasedVehicle: // Option 5 in menu
                            refuelCar();
                            break;

                        case eGarageServicesMenuOptions.RechargeElectricBasedVehicle: // Option 6 in menu
                            rechargeElectricVehicle();
                            break;

                        case eGarageServicesMenuOptions.ViewVehicleInfo: // Option 7 in menu
                            showGarageEntryData();
                            break;

                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("The program was terminated." + ex.Message);
                }
            }
        }

        private void showGarageEntryData()
        {
            Vehicle vehicleToShowInfo = null;
            string vehicleToShowInfoStr = GarageUIUtils.getVehicleLicenseNumber();
            GarageServices.tryGetVehicleByLicense(vehicleToShowInfoStr, out vehicleToShowInfo);
            GarageServices.showGarageEntryData(vehicleToShowInfo);
        }

        private void rechargeElectricVehicle()
        {
            Vehicle vehicleToRecharge = null;
            string vehicleToRechargeStr = GarageUIUtils.getVehicleLicenseNumber();
            GarageServices.tryGetVehicleByLicense(vehicleToRechargeStr, out vehicleToRecharge);

            //$Or - Add method.
            Console.WriteLine("Please enter the amount of energy to charge");
            float energyToadd = float.Parse(Console.ReadLine());
           
            GarageServices.ChargeBattery(vehicleToRechargeStr, energyToadd, vehicleToRecharge);
        }

        private void refuelCar()
        {
            Vehicle vehicleToFuel = null;
            string vehicleToFuelStr = GarageUIUtils.getVehicleLicenseNumber();
            float fuelToadd = float.Parse(Console.ReadLine());
         //   GarageUIUtils.

            if (GarageServices.tryGetVehicleByLicense(vehicleToFuelStr, out vehicleToFuel))
            {
           //      GarageServices.AddFuel(vehicleToFuelStr, fuelToadd, i_FuelType 
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void InflateWheelsToMax()
        {
            Vehicle vehicleToInflateWheels = null;
            string vehicleToInflateLicenseNumStr = GarageUIUtils.getVehicleLicenseNumber();
            if(GarageServices.tryGetVehicleByLicense(vehicleToInflateLicenseNumStr, out vehicleToInflateWheels))
               {
                GarageServices.InflateVehicleWheelsToMax(vehicleToInflateWheels);
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void errorFindingVehicle()
        {
            Console.WriteLine("Could not find Vehicle!!!");
        }

        private void ChangeVehicleStatus()
        {
            Vehicle vehicleToChangeStatus = null;
            eVehicleStatus newVehicleStatus = GarageUIUtils.getVehicleStatus();
            if (GarageServices.tryGetVehicleByLicense(GarageUIUtils.getVehicleLicenseNumber(), out vehicleToChangeStatus))
            {
                GarageServices.ChangeVehicleStatus(vehicleToChangeStatus, newVehicleStatus);
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void displayVehicleList()
        {
            List<string> vehiclesList = new List<string>();

            Console.WriteLine("Would you like to include filtering? Enter y/n.");
            string filter = Console.ReadLine();

            bool v_includeFilter = true;
            eVehicleStatus vehicleStatus = eVehicleStatus.NotDetermined;

            if (filter == "y" || filter == "Y")
            {
                vehicleStatus = GarageUIUtils.getVehicleStatus();
                vehiclesList = GarageServices.GetVehiclesListInGarage(vehicleStatus, v_includeFilter);
            }
            else if (filter == "n" || filter == "N")
            {
                vehiclesList = GarageServices.GetVehiclesListInGarage(eVehicleStatus.NotDetermined, !v_includeFilter);
            }
            else
            {
                Console.WriteLine("Invalid Input");
                displayVehicleList();
            }
            foreach (string vehicleLicenseNumber in vehiclesList)
            {
                Console.WriteLine(vehicleLicenseNumber);
            }
        }

        private void addVehicleToGarage()
        {
            Vehicle vehicleToAdd = null;

            string licenseNumberFromuser = GarageUIUtils.getVehicleLicenseNumber();
            if (GarageServices.tryGetVehicleByLicense(licenseNumberFromuser, out vehicleToAdd))
            {
                GarageServices.ChangeVehicleStatus(vehicleToAdd, eVehicleStatus.Repaired);
            }
            else
            {
                eVehicleType vehicleType = GarageUIUtils.GetVehicleType();
                string modelName = GarageUIUtils.getVehicleModelName();
                string wheelManfucaturerName = GarageUIUtils.getWheelManufacturerName();
                string ownerName = GarageUIUtils.getVehicleOwnerName();
                string ownerPhoneNum = GarageUIUtils.getVehicleOwnerPhoneNum();
                float wheelCurrentAirPressure = GarageUIUtils.getCurrentTiersAirPressure();

                try
                {
                    Dictionary<string, string> uniqueVehicleProperties = GetUniquePropertiesByVehicleType(vehicleType);
                    GarageServices.AddNewGarageEntry(vehicleType, modelName, licenseNumberFromuser, ownerName, ownerPhoneNum, wheelManfucaturerName, wheelCurrentAirPressure, uniqueVehicleProperties);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string getAndValidateUserMenuSelection()
        {
            string choice = Console.ReadLine();
            int userChoiseAsInt;
            bool validInput = true;
            bool inMenu = true;

            do
            {
                validInput = int.TryParse(choice, out userChoiseAsInt);
                inMenu = (userChoiseAsInt >= (int)eGarageServicesMenuOptions.AssignVehicleToRepair) && userChoiseAsInt <= ((int)eGarageServicesMenuOptions.ViewVehicleInfo);
            } while (validInput != true || inMenu != true);

            return choice
        }

        private Dictionary<string, string> GetUniquePropertiesByVehicleType(eVehicleType vehicleType)
        {
            Dictionary<string, string> uniqueVehicleProperties = new Dictionary<string, string>();
            switch (vehicleType)
            {
                case eVehicleType.Car:
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyColor, GarageUIUtils.GetStringFromUser(GarageUIUtils.getCarColor()));
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyNumOfDoors, GarageUIUtils.GetStringFromUser(GarageUIUtils.getNumberOfDoorsInCar()));
                    break;
                case eVehicleType.Motorcycle:
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyEngineVolume, GarageUIUtils.getMotorcycleEngineVolume());
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyLicenseType, GarageUIUtils.getMotorcycleLicenseType());
                    break;
                case eVehicleType.Truck:
                    uniqueVehicleProperties.Add(GarageConstants.k_CarryigHazardousMaterial, GarageUIUtils.DoesContainsHazardousMaterials());
                    uniqueVehicleProperties.Add(GarageConstants.k_MaxLoadingWeight, GarageUIUtils.GetTruckMaxLoadingWeight());
                    break;
            }

            return uniqueVehicleProperties;
        }
    }
}
