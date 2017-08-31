using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        internal ElectricMotorcycle(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
            Engine = new ElectricEngine(); // Please Add needed params in here.
        }

        public override void InitVehicleAdditionalProperties()
        {
            //$Or - Need to somehowadd the properties here. We don't have polymorphism.
            InitElectricMotorcycleProperties();
            return;
        }
        private void InitElectricMotorcycleProperties()
        {
            return;
        }
    }
}
