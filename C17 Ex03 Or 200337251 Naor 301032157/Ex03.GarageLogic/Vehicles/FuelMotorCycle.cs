using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelAmount = 5.5f;
        private const eFuelType k_fuelType = eFuelType.Octan95;

        internal FuelMotorcycle(string i_ModelName, string i_LicenceNumber)
            : base(i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(k_fuelType, k_MaxFuelAmount);
        }
    }
}