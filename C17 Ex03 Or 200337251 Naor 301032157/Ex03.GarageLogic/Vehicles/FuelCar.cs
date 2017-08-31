using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // $Or - Should this be public?
    internal class FuelCar : Car
    {
        private const float k_MaxFuelAmount = 50f;
     
        internal FuelCar(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(FuelEngine.eFuelType.Octan98, k_MaxFuelAmount, EnergyLeftPercentage);
        }

        public override void InitVehicleAdditionalProperties()
        {
            //$Or - Need to somehowadd the properties here. We don't have polymorphism.
            InitFuelCarProperties();
            return;
        }
        private void InitFuelCarProperties()
        {
            return;
        }
    

    }
    
}


