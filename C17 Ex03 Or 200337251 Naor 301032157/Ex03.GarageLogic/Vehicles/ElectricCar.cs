using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_MaxFuelAmount = 50f;

        //$ Or - Please Change the const value to the correct ones in this one and all other classes too please.
        internal ElectricCar(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
           Engine = new ElectricEngine(); // Please Add needed params in here.
        }

        public override void InitVehicleAdditionalProperties()
        {
            //$Or - Need to somehowadd the properties here. We don't have polymorphism.
            InitElectricCarProperties();
            return;
        }
        private void InitElectricCarProperties()
        {
            return;
        }
    }
}
