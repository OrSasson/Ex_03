using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // $Or - Should this be public?
    internal class FuelCar : Car
    {
        private const float k_MaxFuelAmount = 42f;
     

        internal FuelCar(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
            r_FuelEngine = new FuelEngine(FuelEngine.eFuelType.Octan98, k_MaxFuelAmount, EnergyLeftPercentage);
        }


        private readonly Engine r_FuelEngine;
        // $change this.
        public Engine Engine
        {
            get
            {
                return r_FuelEngine;
            }
        }

    }
    
}


