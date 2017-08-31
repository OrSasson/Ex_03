using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   internal class FuelMotorcycle : Motorcycle
    {

        const float k_MaxFuelAmount = 10000;
        internal FuelMotorcycle(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(FuelEngine.eFuelType.Octan98, k_MaxFuelAmount, EnergyLeftPercentage); // Please Correct Values!!!
        }

        public override void InitVehicleAdditionalProperties()
        {
            //$Or - Need to somehowadd the properties here. We don't have polymorphism.
            InitFuelMotorcycleProperties();
            return;
        }
        private void InitFuelMotorcycleProperties()
        {
            return;
        }
    }
}
