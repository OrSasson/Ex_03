using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelTruck : Truck
    {
        private const float k_MaxFuelAmount = 130f;
        private const FuelEngine.eFuelType k_fuelType = FuelEngine.eFuelType.Soler;

        public FuelTruck(string i_ModelName, string i_LicenceNumber)
            : base (i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(k_fuelType, k_MaxFuelAmount);
        }
    }
}
