using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryCapacity = 1.6f;

        public ElectricMotorcycle(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
            Engine = new ElectricEngine(k_MaxBatteryCapacity); 
        }
    }
}
