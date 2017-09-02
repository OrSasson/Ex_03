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
            runGarageServicesSystem();
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
7.{6}.
8.{7}",
"Assign new vehicle for repair",
"View license plates filtered by status",
"Change vehicle status",
"Inflate wheels in vehicle to max pressure",
"Refuel fuel type vehicle",
"Recharge Electric type vehicle",
"View vehicle full detailes",
"Exit Garage Services System.");
        }

        public void GarageMenu()
        {
           
            runGarageServicesSystem();

        }

        private void runGarageServicesSystem()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    displayUserOptions();
                    string choice = getAndValidateUserMenuSelection();

                    //eGarageServicesMenuOptions GarageSystemService = eGarageServicesMenuOptions.NoSelection;
                    eGarageServicesMenuOptions GarageSystemService = (eGarageServicesMenuOptions)Enum.Parse(typeof(eGarageServicesMenuOptions), choice);

                    Console.WriteLine("You chose option number {0}.", choice);

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
                        case eGarageServicesMenuOptions.ExitGarageServices:
                            Console.WriteLine("Thank you for using Garage Services System!");
                            Environment.Exit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid Menu Option!");                                
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

            if (GarageServices.tryGetVehicleByLicense(vehicleToShowInfoStr, out vehicleToShowInfo))
            {
                GarageServices.showGarageEntryData(vehicleToShowInfo);
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void rechargeElectricVehicle()
        {
            Vehicle vehicleToRecharge = null;
            string vehicleToRechargeStr = GarageUIUtils.getVehicleLicenseNumber();
            if(GarageServices.tryGetVehicleByLicense(vehicleToRechargeStr, out vehicleToRecharge))
            {
                float energyToadd = GarageUIUtils.getBatteryAmountToCharge(vehicleToRecharge);
                GarageServices.ChargeBattery(vehicleToRechargeStr, energyToadd, vehicleToRecharge);
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void refuelCar()
        {
            Vehicle vehicleToFuel = null;
            string vehicleToFuelStr = GarageUIUtils.getVehicleLicenseNumber();

            Console.WriteLine("Please Enter amount of fuel to Add.");
            float fuelToadd = float.Parse(Console.ReadLine());
            eFuelType fuelType = GarageUIUtils.getFuelTypeFromUser();

            if (GarageServices.tryGetVehicleByLicense(vehicleToFuelStr, out vehicleToFuel))
            {
                GarageServices.AddFuel(vehicleToFuelStr, fuelToadd, (int)fuelType, vehicleToFuel);
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
            Console.WriteLine("Click any key to run the menu again.");
            Console.ReadKey();
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
                inMenu = (userChoiseAsInt >= (int)eGarageServicesMenuOptions.AssignVehicleToRepair) && userChoiseAsInt <= ((int)eGarageServicesMenuOptions.ExitGarageServices);
            } while (validInput != true || inMenu != true);

            return choice;
        }

        private Dictionary<string, string> GetUniquePropertiesByVehicleType(eVehicleType vehicleType)
        {
            Dictionary<string, string> uniqueVehicleProperties = new Dictionary<string, string>();
            switch (vehicleType)
            {
                case eVehicleType.Car:
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyColor, GarageUIUtils.getCarColor());//*
                    uniqueVehicleProperties.Add(GarageConstants.k_KeyNumOfDoors, GarageUIUtils.getNumberOfDoorsInCar());//*
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
