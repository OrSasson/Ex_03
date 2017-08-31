using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_MaxBatteryCapacity = 2.8f;

        internal ElectricCar(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
           Engine = new ElectricEngine(k_MaxBatteryCapacity); 
        }

        public override void InitVehicleAdditionalProperties()
        {
            //$Or - Need to somehow add the properties here. We don't have polymorphism.
            InitElectricCarProperties();
            return;
        }

        private void InitElectricCarProperties()
        {
            return;
        }
    }
}
