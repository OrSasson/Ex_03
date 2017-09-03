using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_MaxBatteryCapacity = 2.8f;

        public ElectricCar(string i_ModelName, string i_LicenceNumber)
            : base(i_ModelName, i_LicenceNumber)
        {
           Engine = new ElectricEngine(k_MaxBatteryCapacity); 
        }
    }
}