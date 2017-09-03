using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageUI
    {
        internal const int k_GarageServicesMenuOptionsNumber = 9;
        internal const string k_DisplayUserdisplayUserOptions = @"Please chose the required service:
1.Assign new vehicle for repair.
2.View license plates filtered by status.
3.Change vehicle status.
4.Inflate wheels in vehicle to max pressure.
5.Refuel fuel type vehicle.
6.Recharge Electric type vehicle.
7.View vehicle full detailes.
8.Exit Garage Services System.";

        public GarageUI()
        {
            runGarageServicesSystem();
        }

        private void runGarageServicesSystem()
        {
            bool toContinue = true;

            while (toContinue)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(k_DisplayUserdisplayUserOptions);
                    string choice = getAndValidateUserMenuSelection();

                    eGarageServicesMenuOptions GarageSystemService = (eGarageServicesMenuOptions)Enum.Parse(typeof(eGarageServicesMenuOptions), choice);

                    Console.WriteLine("You chose option number {0}.", choice);

                    switch (GarageSystemService)
                    {
                        case eGarageServicesMenuOptions.AssignVehicleToRepair: 
                            addVehicleToGarage();
                            break;

                        case eGarageServicesMenuOptions.ViewVehiclesPlateNumbersByStatus: 
                            displayVehicleList();
                            Console.WriteLine("To return to the menu press any key.");
                            Console.ReadKey();
                            break;

                        case eGarageServicesMenuOptions.ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;

                        case eGarageServicesMenuOptions.InflateVehicleWheelsToMax: 
                            inflateWheelsToMax();
                            break;

                        case eGarageServicesMenuOptions.RefuelFuelBasedVehicle: 
                            refuelCar();
                            break;

                        case eGarageServicesMenuOptions.RechargeElectricBasedVehicle: 
                            rechargeElectricVehicle();
                            break;

                        case eGarageServicesMenuOptions.ViewVehicleInfo: 
                            showGarageEntryData();
                            Console.WriteLine("To return to the menu press any key.");
                            Console.ReadKey();
                            break;
                        case eGarageServicesMenuOptions.ExitGarageServices:
                            Console.WriteLine("Thank you for using Garage Services System!");
                            toContinue = false;
                            break;
                        default:
                            throw new ArgumentException("Invalid Menu Option!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("The program was terminated." + ex.Message);
                }
            }

            Environment.Exit(0);
        }

        private void showGarageEntryData()
        {
            Vehicle vehicleToShowInfo = null;
            string garageEntryData = string.Empty;
            string vehicleToShowInfoStr = GarageUIUtils.getVehicleLicenseNumber();

            if (GarageServices.tryGetVehicleByLicense(vehicleToShowInfoStr, out vehicleToShowInfo))
            {
                Console.WriteLine("Printing Garage Entry Data:");
                garageEntryData = GarageServices.showGarageEntryData(vehicleToShowInfo);
                Console.Clear();
                Console.WriteLine(garageEntryData);
                Console.WriteLine("To return to the menu press any key.");
                Console.ReadKey();
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
                Console.WriteLine("Refuel has succeed, Added {0} liters to the vehicle with the license plate {1}.", fuelToadd, vehicleToFuelStr);
                Console.WriteLine("To return to the menu press any key.");
                Console.ReadKey();
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

            if (GarageServices.tryGetVehicleByLicense(vehicleToRechargeStr, out vehicleToRecharge))
            {
                float energyToadd = GarageUIUtils.getBatteryAmountToCharge(vehicleToRecharge);
                GarageServices.ChargeBattery(vehicleToRechargeStr, energyToadd, vehicleToRecharge);
                Console.WriteLine("Recharge has succeed, charged {0} minutes the battery of the vehicle with the license plate {1}.", energyToadd, vehicleToRechargeStr);
                Console.WriteLine("To return to the menu press any key.");
                Console.ReadKey();
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void inflateWheelsToMax()
        {
            Vehicle vehicleToInflateWheels = null;
            string vehicleToInflateLicenseNumStr = GarageUIUtils.getVehicleLicenseNumber();

            if (GarageServices.tryGetVehicleByLicense(vehicleToInflateLicenseNumStr, out vehicleToInflateWheels))
            {
                GarageServices.InflateVehicleWheelsToMax(vehicleToInflateWheels);
                Console.WriteLine("The wheels of the vehicle with the license plate {0} was inflate to max pressure.", vehicleToInflateLicenseNumStr);
                Console.WriteLine("To return to the menu press any key.");
                Console.ReadKey();
            }
            else
            {
                errorFindingVehicle();
            }
        }

        private void errorFindingVehicle()
        {
            Console.WriteLine("Could not find Vehicle!!!");
            Console.WriteLine("To return to the menu press any key.");
            Console.ReadKey();
        }

        private void changeVehicleStatus()
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
            string filter = Console.ReadLine().ToLower();

            bool v_includeFilter = true;
            eVehicleStatus vehicleStatus = eVehicleStatus.All;

            if (filter == "y")
            {
                vehicleStatus = GarageUIUtils.getVehicleStatus();
                vehiclesList = GarageServices.GetVehiclesListInGarage(vehicleStatus, v_includeFilter);
            }
            else if (filter == "n")
            {
                vehiclesList = GarageServices.GetVehiclesListInGarage(eVehicleStatus.All, !v_includeFilter);
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
                Console.WriteLine("The Vehicle " + licenseNumberFromuser + " already Exists!");
                GarageServices.ChangeVehicleStatus(vehicleToAdd, eVehicleStatus.Repaired);
            }
            else
            {
                eVehicleType vehicleType = GarageUIUtils.getVehicleType();
                string modelName = GarageUIUtils.getVehicleModelName();
                string wheelManfucaturerName = GarageUIUtils.getWheelManufacturerName();
                string ownerName = GarageUIUtils.getVehicleOwnerName();
                string ownerPhoneNum = GarageUIUtils.getVehicleOwnerPhoneNum();

                try
                {
                    Dictionary<string, string> uniqueVehicleProperties = GetUniquePropertiesByVehicleType(vehicleType);
                    GarageServices.AddNewGarageEntry(vehicleType, modelName, licenseNumberFromuser, wheelManfucaturerName, ownerName, ownerPhoneNum, uniqueVehicleProperties);
                    Console.WriteLine("Vehicle was assigned to repair.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("To return to the menu press any key.");
            Console.ReadKey();
        }

        private string getAndValidateUserMenuSelection()
        {
            string choice = string.Empty;
            int userChoiseAsInt;
            bool validInput = true;
            bool inMenu = true;

            do
            {
                choice = Console.ReadLine();
                validInput = int.TryParse(choice, out userChoiseAsInt);
                inMenu = userChoiseAsInt >= 0 && userChoiseAsInt <= k_GarageServicesMenuOptionsNumber;

                if (!inMenu)
                {
                    Console.WriteLine("Wrong input, Please try again.");
                }
            }
            while (!validInput || !inMenu);

            return choice;
        }

        private Dictionary<string, string> GetUniquePropertiesByVehicleType(eVehicleType vehicleType)
        {
            Dictionary<string, string> uniqueVehicleProperties = new Dictionary<string, string>();
            string firstPropertyValue = string.Empty;
            string SecPropertyValue = string.Empty;

            switch (vehicleType)
            {
                case eVehicleType.ElectricCar:
                    firstPropertyValue = GarageUIUtils.getCarColor();
                    SecPropertyValue = GarageUIUtils.getNumberOfDoorsInCar();
                    addVehicleUniqueProperties(uniqueVehicleProperties, GarageConstants.k_KeyColor, firstPropertyValue, GarageConstants.k_KeyNumOfDoors, SecPropertyValue);
                    break;
                case eVehicleType.FuelCar:
                    firstPropertyValue = GarageUIUtils.getCarColor();
                    SecPropertyValue = GarageUIUtils.getNumberOfDoorsInCar();
                    addVehicleUniqueProperties(uniqueVehicleProperties, GarageConstants.k_KeyColor, firstPropertyValue, GarageConstants.k_KeyNumOfDoors, SecPropertyValue);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    firstPropertyValue = GarageUIUtils.getMotorcycleEngineVolume();
                    SecPropertyValue = GarageUIUtils.getMotorcycleLicenseType();
                    addVehicleUniqueProperties(uniqueVehicleProperties, GarageConstants.k_KeyEngineVolume, firstPropertyValue, GarageConstants.k_KeyLicenseType, SecPropertyValue);
                    break;
                case eVehicleType.FuelMotorcycle:
                    firstPropertyValue = GarageUIUtils.getMotorcycleEngineVolume();
                    SecPropertyValue = GarageUIUtils.getMotorcycleLicenseType();
                    addVehicleUniqueProperties(uniqueVehicleProperties, GarageConstants.k_KeyEngineVolume, firstPropertyValue, GarageConstants.k_KeyLicenseType, SecPropertyValue);
                    break;
                case eVehicleType.FuelTruck:
                    firstPropertyValue = GarageUIUtils.DoesContainsHazardousMaterials();
                    SecPropertyValue = GarageUIUtils.GetTruckMaxLoadingWeight();
                    addVehicleUniqueProperties(uniqueVehicleProperties, GarageConstants.k_CarryigHazardousMaterial, firstPropertyValue, GarageConstants.k_MaxLoadingWeight, SecPropertyValue);
                    break;
                default:
                    throw new ArgumentException("Invalid Menu Option!");
            }

            return uniqueVehicleProperties;
        }

        private void addVehicleUniqueProperties(Dictionary<string, string> i_UniqueVehicleProperties, string i_FirstProperty, string i_FirsrtPropertyValue, string i_SecProperty, string i_SecPropertyValue)
        {
            i_UniqueVehicleProperties.Add(i_FirstProperty, i_FirsrtPropertyValue);
            i_UniqueVehicleProperties.Add(i_SecProperty, i_SecPropertyValue);
        }
    }
}
