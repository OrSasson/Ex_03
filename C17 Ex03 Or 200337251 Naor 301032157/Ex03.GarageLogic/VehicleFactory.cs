using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal static class VehicleFactory
    {
        public static Vehicle CreateVehicle(int i_VehicleType, string i_ModelName, string i_LicenceNumber)
        {
            Vehicle newVehicle = null;

            try
            {
                eVehicleType vehicleType = (eVehicleType)i_VehicleType;

                switch (vehicleType)
                {
                    case eVehicleType.FuelCar:
                        newVehicle = new FuelCar(i_ModelName, i_LicenceNumber);
                        break;
                    case eVehicleType.ElectricCar:
                        newVehicle = new ElectricCar(i_ModelName, i_LicenceNumber);
                        break;
                    case eVehicleType.ElectricMotorcycle:
                        newVehicle = new ElectricMotorcycle(i_ModelName, i_LicenceNumber);
                        break;
                    case eVehicleType.FuelMotorcycle:
                        newVehicle = new FuelMotorcycle(i_ModelName, i_LicenceNumber);
                        break;
                    case eVehicleType.FuelTruck:
                        newVehicle = new FuelTruck(i_ModelName, i_LicenceNumber);
                        break;
                }
            }
            catch
            {
                throw new ArgumentException("No matching vehicle was found!!");
            }

            return newVehicle;
        }

    //    internal enum eVehicleType : byte
    //    {
    //        FuelCar = 1,
    //        ElectricCar,
    //        FuelMotorcycle,
    //        ElectricMotorcycle,
    //        FuelTruck
    //    }
    }
}