using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    // $Or - Should this be public?
    internal class FuelCar : Car
    {
        private const float k_MaxFuelAmount = 50f;
        private const eFuelType k_fuelType =  eFuelType.Octan98;


        internal FuelCar(string i_ModelName, string i_LicenceNumber)
            : base( i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(k_fuelType, k_MaxFuelAmount);
        }
    }
    
}