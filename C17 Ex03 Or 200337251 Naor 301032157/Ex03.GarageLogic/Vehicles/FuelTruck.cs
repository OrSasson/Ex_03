using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelTruck : Truck
    {
        private const float k_MaxFuelAmount = 130f;

        public FuelTruck(string i_ModelName, string i_LicenceNumber)
            : base (i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(FuelEngine.eFuelType.Soler, k_MaxFuelAmount);
        }

        public override void InitUniqueVehicleTypeProperties()
        {
            throw new NotImplementedException();
        }

    }
}
